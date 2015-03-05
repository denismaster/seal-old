using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seal2D.Core.Figures;
using SharpDX;

namespace Seal2D.Core.Figures
{
    public abstract class SolidFigure : Figure, IMoveable, ILineEndable, IBoundable,IColorable
    {
        public const int defaultSize = 25;
        private SharpDX.Color4 _brushColor = SharpDX.Color.White;
        private SharpDX.Point _location;
        public event EventHandler<Figures.LocationEventsArgs> FigureMoved;

        public SharpDX.Direct2D1.Geometry Geometry
        {
            get;
            set;
        }
        public SharpDX.Color4 Color
        {
            get
            {
                return _brushColor;
            }
            set
            {
                _brushColor = value;
            }
        }
        public SharpDX.Point Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        public SharpDX.Vector2 LineEnd
        {
            get
            {
                Vector2 v = new Vector2();
                v.X = Location.X + Geometry.GetBounds().Width / 2;
                v.Y = Location.Y + Geometry.GetBounds().Height / 2;
                return v;
            }
        }
        public SharpDX.RectangleF Bounds
        {
            get
            {
                RectangleF bounds = Geometry.GetBounds();
                return new RectangleF(bounds.Left + Location.X, bounds.Top + Location.Y, bounds.Width, bounds.Height);
            }
        }
        public void Offset(int dx, int dy)
        {
            _location.X += dx;
            _location.Y += dy;
            if (_location.X < 0)
            {
                _location.X = 0;
            }
            if (_location.Y < 0)
                _location.Y = 0;

            if (FigureMoved != null)
                FigureMoved(this, new LocationEventsArgs(Location.X, Location.Y));
        }
        public override bool IsPointInside(Point p)
        {
            Point here = new Point(p.X - Location.X, p.Y - Location.Y);
            if (Geometry != null)
                return Geometry.StrokeContainsPoint(here, 1) || Geometry.FillContainsPoint(here);
            else
                return false;
        }
        public override ICollection<Marker> CreateMarkers()
        {
            LinkedList<Marker> markers = new LinkedList<Marker>();
            Marker m = new SizeMarker();
            m.targetFigure = this;
            markers.AddLast(m);
            return markers;
        }
        public void OnFigureMove(object sender, Figures.LocationEventsArgs e)
        {
            if (FigureMoved != null)
            {
                FigureMoved(sender, e);
            }
        }
        public override void Draw(Drawing.DrawingContext dc)
        {
            try
            {
                dc.D2DTarget.Transform = Matrix.AffineTransformation2D(1.0f, MathUtil.DegreesToRadians(0), new Vector2
                    (this.Location.X, this.Location.Y));
                dc.SolidBrush.Color = this.Color;
                dc.D2DTarget.FillGeometry(this.Geometry, dc.SolidBrush);
                dc.D2DTarget.DrawGeometry(this.Geometry, dc.StrokeBrush, 1);
                //if (this.CompiledText != null && this.TextRect.Width >= this.CompiledText.Metrics.WidthIncludingTrailingWhitespace)
                //    g.DrawTextLayout(this.TextRect.TopLeft, this.CompiledText, dc.StrokeBrush);
            }
            finally
            {
                dc.D2DTarget.Transform = SharpDX.Matrix.Identity;
            }
        }
        
    }
}

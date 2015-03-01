using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seal2D.Core.Figures;

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
        public override bool IsInsidePoint(Point p)
        {
            Point here = new Point(p.X - Location.X, p.Y - Location.Y);
            if (Geometry != null)
                return Geometry.StrokeContainsPoint(here, 1) || Geometry.FillContainsPoint(here);
            else
                return false;
        }
        public ICollection<Marker> CreateMarkers()
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
        
    }
}

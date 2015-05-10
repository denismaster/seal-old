using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using Math = System.Math;
namespace Seal.Figures
{
    public abstract class Marker : Seal.Figures.Figure, IMoveable, ILineEndable
    {
        public Marker()
        {
            _drawingEllipse = new SharpDX.Direct2D1.Ellipse(Vector2.Zero, defaultSize + 1, defaultSize + 1);
        }
        private Location _location;
        public Location Location
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
        public Location LineEnd
        {
            get
            {
                return _location;
            }
        }
        public virtual void Offset(float dx, float dy)
        {
            _location.X += dx;
            _location.Y += dy;
            if (_location.X < 0)
            {
                _location.X = 0;
            }
            if (_location.Y < 0)
                _location.Y = 0;
            OnFigureMove(this, new LocationEventsArgs(Location.X, Location.Y));
        }
        public event EventHandler<LocationEventsArgs> FigureMoved;

        public virtual void OnFigureMove(object sender, LocationEventsArgs e)
        {
            if (FigureMoved != null)
            {
                FigureMoved(sender, e);
            }
        }

        protected static  int defaultSize = 4;

        public Figure targetFigure;

        private SharpDX.Direct2D1.Ellipse _drawingEllipse;

        public override bool IsPointInside(ref Point p)
        {
            if (p.X < Location.X - defaultSize || p.X > Location.X + defaultSize)
                return false;
            if (p.Y < Location.Y - defaultSize || p.Y > Location.Y + defaultSize)
                return false;
            return true;
        }

        public override void Draw(Drawing.DrawingContext g)
        {
            g.D2DTarget.Transform = Matrix.Identity;
            _drawingEllipse.Point = Location;
            g.D2DTarget.FillEllipse(_drawingEllipse, g.MarkerBrush);

            g.D2DTarget.DrawEllipse(_drawingEllipse, g.StrokeBrush, 0.5f);
        }

        public abstract void UpdateLocation();
    }
    public class SizeMarker : Marker
    {
        public override void UpdateLocation()
        {
            RectangleF bounds = (targetFigure as IBoundable).Bounds;
            Location = new Location((int)System.Math.Round(bounds.Right) + defaultSize / 2, (int)System.Math.Round(bounds.Bottom) + defaultSize / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);
            (targetFigure as IScaleable).Size = new Size((targetFigure as IScaleable).Size.Width + dx,
                (targetFigure as IScaleable).Size.Height + dy);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
namespace Seal2D.Core.Figures
{
    public abstract class Marker : Seal2D.Core.Figures.FigureBase, IMoveable
    {
        public Marker()
        {
        }
        private Point _location;
        public Point Location
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
        public virtual void Offset(int dx, int dy)
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

        protected static  int defaultSize = 2;

        public Figure targetFigure;

        public override bool IsPointInside(Point p)
        {
            if (p.X < Location.X - defaultSize || p.X > Location.X + defaultSize)
                return false;
            if (p.Y < Location.Y - defaultSize || p.Y > Location.Y + defaultSize)
                return false;
            return true;
        }

        public override void Draw(Drawing.DrawingContext g)
        {
            g.D2DTarget.Transform = Matrix.Translation(Location.X, Location.Y, 0);
            RectangleF rect = new RectangleF(0, 0, defaultSize, defaultSize);
            g.D2DTarget.FillRectangle(rect, g.SolidBrush);
            g.D2DTarget.DrawRectangle(rect, g.SolidBrush, 1);
            g.D2DTarget.Transform = Matrix.Identity;
        }

        public abstract void UpdateLocation();
    }
    public class SizeMarker : Marker
    {
        public override void UpdateLocation()
        {
            RectangleF bounds = (targetFigure as IBoundable).Bounds;
            Location = new Point((int)Math.Round(bounds.Right) + defaultSize / 2, (int)Math.Round(bounds.Bottom) + defaultSize / 2);
        }

        public override void Offset(int dx, int dy)
        {
            base.Offset(dx, dy);
            (targetFigure as IScaleable).Size = new Size2F((targetFigure as IScaleable).Size.Width + dx,
                (targetFigure as IScaleable).Size.Height + dy);
        }
    }
}

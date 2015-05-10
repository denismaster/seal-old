using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Geometries
{
    public class EllipseGeometry : IFilledGeometry
    {
        private SharpDX.Direct2D1.Ellipse _ellipse = new SharpDX.Direct2D1.Ellipse(SharpDX.Vector2.Zero, 25 / 2, 25 / 2);

        public Size Size
        {
            get
            {
                return new Size(_ellipse.RadiusX * 2, _ellipse.RadiusY * 2);
            }
            set
            {
                _ellipse.RadiusX = value.Width / 2;
                _ellipse.RadiusY = value.Height / 2;
            }
        }

        public void Draw(Drawing.DrawingContext dc,SharpDX.Vector2 where, int strokeWidth=1)
        {

            _ellipse.Point.X = where.X + _ellipse.RadiusX;
            _ellipse.Point.Y = where.Y + _ellipse.RadiusY;
            dc.DrawEllipse(_ellipse, where, strokeWidth);
        }

        public bool Contains(ref SharpDX.Point p)
        {
            return new SharpDX.RectangleF(_ellipse.Point.X - _ellipse.RadiusX,
                _ellipse.Point.Y - _ellipse.RadiusY, _ellipse.RadiusX * 2, _ellipse.RadiusY * 2).Contains(p);
        }
    }
}

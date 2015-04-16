using System;
using System.Collections.Generic;
using System.Linq;

namespace Seal2D.Core.Geometries
{
    public class RectangleGeometry:IFilledGeometry
    {
        private SharpDX.RectangleF _rectangle = new SharpDX.RectangleF(0, 0, 25, 25);
        
        public SharpDX.Size2F Size
        {
            get
            {
                return _rectangle.Size;
            }
            set
            {
                _rectangle.Size = value;
            }
        }

        public void Draw(Drawing.DrawingContext dc, SharpDX.Vector2 where)
        {
            
            _rectangle.Location = where;
            dc.DrawRectangle(this._rectangle, where);
        }

        public bool Contains(SharpDX.Point p)
        {
            return _rectangle.Contains(p);
        }
    }
}

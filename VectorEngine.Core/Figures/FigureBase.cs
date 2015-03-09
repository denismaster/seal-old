using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal2D.Core.Figures
{
    public abstract class Figure : Seal2D.Core.Figures.VectorObject
    {
        public static SharpDX.Direct2D1.Factory D2DFactory
        {
            get;
            set;
        }

        public abstract bool IsPointInside(SharpDX.Point p);

        public abstract void Draw(Drawing.DrawingContext dc);
    }
}

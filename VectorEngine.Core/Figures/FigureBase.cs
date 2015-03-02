using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal2D.Core.Figures
{
    public abstract class FigureBase : Seal2D.Core.Figures.VectorObject
    {
        public SharpDX.Direct2D1.Factory D2DFactory
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public abstract bool IsPointInside(SharpDX.Point p);

        public abstract void Draw(Drawing.DrawingContext dc);
    }
}

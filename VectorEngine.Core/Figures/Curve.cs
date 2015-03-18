using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal2D.Core
{
    public abstract class Curve : Seal2D.Core.Figures.LineBase
    {
        public override bool IsPointInside(SharpDX.Point p)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            throw new NotImplementedException();
        }
    }
}

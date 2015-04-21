using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal
{
    public abstract class Curve : Seal.Figures.LineBase
    {
        public override bool IsPointInside(ref SharpDX.Point p)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            throw new NotImplementedException();
        }
    }
}

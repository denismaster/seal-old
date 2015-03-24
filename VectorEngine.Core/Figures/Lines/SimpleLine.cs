using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal2D.Core.Figures
{
    public class Line : Seal2D.Core.Figures.LineBase
    {
        public override bool IsPointInside(SharpDX.Point p)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            dc.D2DTarget.DrawLine(this.From.LineEnd, this.To.LineEnd, dc.StrokeBrush);
        }
    }
}

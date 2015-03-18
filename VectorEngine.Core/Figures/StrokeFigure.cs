using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX.Direct2D1;
using SharpDX;
namespace Seal2D.Core
{
    public class StrokeFigure : Seal2D.Core.Figures.Figure
    {
        public Geometry Path;
        public override bool IsPointInside(SharpDX.Point p)
        {
            return false;
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            var g = dc.D2DTarget;
            g.DrawGeometry(Path, dc.SolidBrush);

        }
    }
}

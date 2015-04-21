using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX.Direct2D1;
using SharpDX;
namespace Seal
{
    public class StrokeFigure : Seal.Figures.Figure
    {
        private ICollection<Vector2> points;
        private Color color = Color.Blue;
        private float lineWidth = 10;
        public StrokeFigure(ICollection<Vector2> ps)
        {
            if(ps==null)
            {
                throw new ArgumentNullException();
            }
            points = ps;
        }

        public override bool IsPointInside(ref SharpDX.Point p)
        {
            return false;
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            var g = dc.D2DTarget;
            var start = points.First();
            foreach(var p in points)
            {
                if (p == start) continue;
                else
                {
                    dc.SolidBrush.Color=color;
                    dc.D2DTarget.DrawLine(start, p, dc.SolidBrush, lineWidth);
                    start = p;
                }
            }

        }
    }
}

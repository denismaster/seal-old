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
        private Color color;
        private int lineWidth;
        public StrokeFigure(ICollection<Vector2> ps,Color color,int width = 3)
        {
            this.color = color;
            this.lineWidth = width;
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

        public override void Draw(Drawing.IDrawingContext dc)
        {
            //var g = D2D;
            var start = points.First();
            foreach(var p in points)
            {
                if (p == start) continue;
                else
                {
                    dc.StrokeColor=color;
                    dc.DrawLine(start, p, lineWidth);
                    start = p;
                }
            }

        }
    }
}

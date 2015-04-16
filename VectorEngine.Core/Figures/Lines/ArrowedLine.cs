using System;
using System.Collections.Generic;
using SharpDX;
namespace Seal2D.Core.Figures
{
    public class ArrowedLine : Line
    {
        private Vector2 lineEnd1;
        private Vector2 lineEnd2;
        private Vector2 centerX;
        public ArrowedLine(ILineEndable from, ILineEndable to)
        {
            if (from == null || to == null)
            {
                throw new ArgumentNullException();
            }
            this.From = from;
            this.To = to;
            if (from is IMoveable)
                (from as IMoveable).FigureMoved += RecalcLine;
            if (to is IMoveable)
                (to as IMoveable).FigureMoved += RecalcLine;
            RecalcLine(null, new LocationEventsArgs(0, 0));
        }
        private void RecalcLine(object sender, LocationEventsArgs e)
        {
            Vector2 center = 0.5f * (From.LineEnd + To.LineEnd);
            Vector2 lineVector = To.LineEnd - From.LineEnd;
            lineVector.Normalize();
           centerX = center + lineVector * 10;
            Vector2 orthoVector1;
            if (0 == lineVector.X)
            {
                orthoVector1 = new Vector2(5, 0);
            }
            else if (0 == lineVector.Y)
            {
                orthoVector1 = new Vector2(0, 5);
            }
            else
            {
                orthoVector1 = new Vector2(5, -lineVector.X * 5 / lineVector.Y);
                orthoVector1.Normalize();
                orthoVector1 *= 5;
            }
            lineEnd1 = center - orthoVector1;
            lineEnd2 = center + orthoVector1;
        }
        public override void Draw(Drawing.DrawingContext dc)
        {
            dc.D2DTarget.DrawLine(From.LineEnd, To.LineEnd, dc.StrokeBrush);
            dc.D2DTarget.DrawLine(centerX, lineEnd1, dc.StrokeBrush);
            dc.D2DTarget.DrawLine(centerX, lineEnd2, dc.StrokeBrush);
        }
    }
}

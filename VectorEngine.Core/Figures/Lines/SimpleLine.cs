using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Seal2D.Core.Figures
{
    public class Line : Seal2D.Core.Figures.LineBase
    {
        public static Func<SharpDX.Point, Figure> FindDelegate;
        public override bool IsPointInside(SharpDX.Point p)
        {
            var p0 = this.From.LineEnd;
            var p1 = this.To.LineEnd;
            var p0p = new SharpDX.Vector3(p.X - p0.X, p.Y - p0.Y, 0);
            var p0p1 = new SharpDX.Vector3(p1.X - p0.X, p1.Y - p0.Y, 0);
            var cross = SharpDX.Vector3.Cross(p0p, p0p1);
            return Math.Abs(cross.Length()) < 10;
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            dc.D2DTarget.DrawLine(this.From.LineEnd, this.To.LineEnd, dc.StrokeBrush);
        }

        public override LinkedList<Marker> CreateMarkers()
        {
            EndLineMarker m1 = new EndLineMarker(FindDelegate, 0);
            EndLineMarker m2 = new EndLineMarker(FindDelegate, 1);
            m1.targetFigure = this;
            m2.targetFigure = this;
            var list = new LinkedList<Marker>();
            list.AddLast(m1);
            list.AddLast(m2);
            return list;
        }
    }
}

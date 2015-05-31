using System;
using System.Collections.Generic;
namespace Seal.Figures
{
    public class Line : Seal.Figures.LineBase
    {
        public static Func<SharpDX.Point, Figure> FindDelegate;
        public override bool IsPointInside(ref SharpDX.Point p)
        {
            var v1 = (Location)From.LineEnd;
            var v2 = (Location)To.LineEnd;
            return Seal.Math.IsPointInSegment(ref p,ref v1, ref v2);
        }
        public Line(ILineEndable From, ILineEndable To):base(From, To)
        {

        }
       
        public override void Draw(Drawing.IDrawingContext dc)
        {
            dc.StrokeColor = this.Color;
            dc.DrawLine(this.From.LineEnd, this.To.LineEnd);
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

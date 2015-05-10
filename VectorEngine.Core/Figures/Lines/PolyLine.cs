using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal.Figures
{
    public class PolyLine : Line, IPointControllable
    {
        private List<Location> _points;

        public PolyLine(ILineEndable From, ILineEndable To, params Location[] points):base(From,To)
        {
            _points = new List<Location>();
            if (points != null)
            {
                foreach (var p in points)
                {
                    _points.Add(p);
                }
            }
        }
        private void OnMarkerMove(object sender, LocationEventsArgs e)
        {
            var ex = e as MarkerEventArgs;
            if (ex != null)
                _points[ex.Index] = new Location(ex.X, ex.Y);
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
            for (int i = 0; i < _points.Count; i++)
            {
                var c = new ControlMarker(i, _points[i]);
                c.targetFigure = this;
                c.FigureMoved += OnMarkerMove;
                list.AddLast(c);
            }
            return list;
        }
        public override bool IsPointInside(ref SharpDX.Point p)
        {
            Location p0 = (Location)From.LineEnd;
            Location pn;
            bool check;
            foreach (var point in _points)
            {
                pn = (Location)point;
                check = Seal.Math.IsPointInSegment(ref p, ref p0, ref pn);
                if (check) return true;
                p0 = pn;
            }
            pn = (Location)To.LineEnd;
            return Seal.Math.IsPointInSegment(ref p, ref p0, ref pn);
        }
        public override void Draw(Drawing.DrawingContext dc)
        {
            SharpDX.Vector2 p0 = From.LineEnd;
            SharpDX.Vector2 pn;
            foreach (var p in _points)
            {
                pn = p;
                dc.DrawLine(p0, pn);
                p0 = pn;
            }
            dc.DrawLine(p0, To.LineEnd);

        }

        public Location GetPoint(int index)
        {
            if (index < 0 || index >= _points.Count) return From.LineEnd;
            else
                return _points[index];
        }
    }
}

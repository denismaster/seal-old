using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Figures
{
    public class CurveLine : Line, IPointControllable
    {
        public static float Ratio = 0.02f;
        private List<Location> _controlPoints;
        private LinkedList<Location> _points;
        private void GetPointValue(Location[] points, float t)
        {
            float x, y;
            if (points.Length == 1)
                _points.AddLast(points[0]);
            else
            {
                Location[] newpoints = new Location[points.Length - 1];
                for (int i = 0; i < newpoints.Length; i++)
                {
                    x = (1 - t) * points[i].X + t * points[i + 1].X;
                    y = (1 - t) * points[i].Y + t * points[i + 1].Y;
                    newpoints[i] = new Location(x, y);
                }
                GetPointValue(newpoints, t);
            }
        }
        private void RecalcLine()
        {
            _points.Clear();
           // _points = new LinkedList<SharpDX.Vector2>();
            float t = 0;
            var delta = Ratio + _controlPoints.Count / 2;
            while(t<=1)
            {
                GetPointValue(_controlPoints.ToArray(), t);
                t += Ratio;
            }
            //Console.WriteLine("Point count:{0}", _points.Count);
        }
        private void OnFirstPointChanged(object sender, LocationEventsArgs e)
        {
            _controlPoints[0] = From.LineEnd;
            RecalcLine();
        }
        private void OnLastPointChanged(object sender, LocationEventsArgs e)
        {
            _controlPoints[_controlPoints.Count - 1] = To.LineEnd;
            RecalcLine();
        }
        private void OnMarkerMove(object sender, LocationEventsArgs e)
        {
            var ex = e as MarkerEventArgs;
            if (ex != null)
            {
                _controlPoints[ex.Index] = new Location(ex.X, ex.Y);
                RecalcLine();
            }
        }
        public CurveLine(ILineEndable From, ILineEndable To, params Location[] points):base(From, To)
        {
            _controlPoints = new List<Location>();
            _points = new LinkedList<Location>();
            _controlPoints.Add(From.LineEnd);
            if (points != null)
            {
                foreach (var p in points)
                {
                    _controlPoints.Add(p);
                }
            }
            _controlPoints.Add(To.LineEnd);
            if (To is IMoveable)
                (To as IMoveable).FigureMoved += OnLastPointChanged;
            if (From is IMoveable)
                (From as IMoveable).FigureMoved += this.OnFirstPointChanged;
            RecalcLine();
        }
        public override void Draw(Drawing.IDrawingContext dc)
        {
            dc.StrokeColor = this.Color;
            if (_points.Count < 2) return;
            SharpDX.Vector2 p0 = _points.First();
            SharpDX.Vector2 pn;
            for (var i = _points.First.Next; i != null;i=i.Next )
            {
                pn = i.Value;
                dc.DrawLine(p0, pn,1);
                p0 = pn;
            }

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
            for (int i = 1; i < _controlPoints.Count-1; i++)
            {
                var c = new ControlMarker(i, _controlPoints[i]);
                c.targetFigure = this;
                c.FigureMoved += OnMarkerMove;
                list.AddLast(c);
            }
            return list;
        }
        public override bool IsPointInside(ref SharpDX.Point p)
        {
            foreach(var q in _points)
            {
                var dx = System.Math.Abs(q.X - p.X);
                var dy = System.Math.Abs(q.Y - p.Y);
                if (dx*dy < 5E-1) return true;
            }
            return false;
        }
        public Location GetPoint(int index)
        {
            if (index < 0 || index >= _controlPoints.Count) return From.LineEnd;
            else
                return _controlPoints.ToArray()[index];
        }

    }
}

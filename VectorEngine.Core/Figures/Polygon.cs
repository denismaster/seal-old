using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Figures
{
    public class Polygon : Figure, IMarkerable, IPointControllable, IFillColorable
    {
        private SharpDX.Direct2D1.PathGeometry _path;
        public const int DefaultSize = 50;
        private List<Location> _points;
        public Polygon(int pointCount, int X = 0, int Y = 0)
        {
            Color = SharpDX.Color.Black;
            FillColor = SharpDX.Color.White;
            if (pointCount < 3) throw new ArgumentOutOfRangeException();
            _points = new List<Location>();
            var delta = 360 / pointCount;
            for (int i = 0; i < pointCount; i++)
            {
                Location Point;
                var angle = delta * i * System.Math.PI / 180;
                var x = X + (float)System.Math.Cos(angle) * DefaultSize;
                var y = Y + (float)System.Math.Sin(angle) * DefaultSize;
                Point = new Location(x, y);
                _points.Add(Point);
            }
            RecalcPath();
        }
        public Polygon(params Location[] points)
        {
        }

        private void RecalcPath()
        {
            if (_path != null)
            {
                _path.Dispose();
                _path = null;
            }
            _path = new SharpDX.Direct2D1.PathGeometry(D2DFactory);
            var sink = _path.Open();
            sink.BeginFigure(_points[0], SharpDX.Direct2D1.FigureBegin.Filled);
            for (int i = 0; i < _points.Count; i++)
            {
                sink.AddLine(_points[i]);
            }
            sink.EndFigure(SharpDX.Direct2D1.FigureEnd.Closed);
            sink.Close();
        }

        public override bool IsPointInside(ref SharpDX.Point p)
        {
            SharpDX.Point here = p;
            if (_path != null)
                return _path.StrokeContainsPoint(here, 1) || _path.FillContainsPoint(here);
            else
                return false;
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            dc.SolidBrush.Color = FillColor;
            dc.StrokeBrush.Color = Color;
            //dc.D2DTarget.Transform = SharpDX.Matrix.Translation(100,100,0);
            dc.D2DTarget.FillGeometry(_path, dc.SolidBrush);
            dc.D2DTarget.DrawGeometry(_path, dc.StrokeBrush);
            dc.D2DTarget.Transform = SharpDX.Matrix.Identity;
        }

        public Location GetPoint(int index)
        {
            if (index < 0 || index >= _points.Count)
                return _points[0];
            return _points[index];
        }
        private void OnMarkerMove(object sender, LocationEventsArgs e)
        {
            var ex = e as MarkerEventArgs;
            if (ex != null)
            {
                _points[ex.Index] = new Location(ex.X, ex.Y);
                RecalcPath();
            }
        }
        public LinkedList<Marker> CreateMarkers()
        {
            var list = new LinkedList<Marker>();
            for (int i = 0; i < _points.Count; i++)
            {
                var c = new ControlMarker(i, _points[i]);
                c.targetFigure = this;
                c.FigureMoved += OnMarkerMove;
                list.AddLast(c);
            }
            return list;
        }

        public SharpDX.Color4 FillColor
        {
            get;
            set;
        }

        public SharpDX.Color4 Color
        {
            get;
            set;
        }


        public int StrokeWidth
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal.Figures
{
    public class Polygon : Figure, IMarkerable, IPointControllable, IFillColorable, IMoveable
    {
        private Location _location;
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
            _location = getLocation();
            _location = new Location(_location.X - X, _location.Y - Y);
            //for(int i=0;i<_points.Count;i++)
            //{
            //    _points[i] = new Location(_points[i].X + _location.X+X, _points[i].Y + _location.Y+Y);
            //}
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
            var new_path = new SharpDX.Direct2D1.PathGeometry(D2D.Instanse.D2DFactory);
            var sink = new_path.Open();
            sink.BeginFigure(_points[0], SharpDX.Direct2D1.FigureBegin.Filled);
            for (int i = 0; i < _points.Count; i++)
            {
                sink.AddLine(_points[i]);
            }
            sink.EndFigure(SharpDX.Direct2D1.FigureEnd.Closed);
            sink.Close();
            sink.Dispose();
            _path = new_path;
        }

        public override bool IsPointInside(ref SharpDX.Point p)
        {
            var px = Convert.ToInt32(p.X - _location.X);
            var py = Convert.ToInt32(p.Y - _location.Y);
            SharpDX.Point here = new SharpDX.Point(px,py);
            if (_path != null)
                return _path.StrokeContainsPoint(here, 1) || _path.FillContainsPoint(here);
            else
                return false;
        }

        public override void Draw(Drawing.IDrawingContext dc)
        {
            var xdc = dc as Drawing.DrawingContext;
            xdc.FillColor = FillColor;
            xdc.StrokeColor = Color;
            xdc.Translate(_location.X, _location.Y);
            xdc.D2DTarget.FillGeometry(_path, xdc.SolidBrush);
           xdc.D2DTarget.DrawGeometry(_path, xdc.StrokeBrush);
            dc.IdentityTransform();
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
                //if (FigureMoved == null)
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

        public SharpDX.Color FillColor
        {
            get;
            set;
        }

        public SharpDX.Color Color
        {
            get;
            set;
        }


        public int StrokeWidth
        {
            get;
            set;
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        public void Offset(float dx, float dy)
        {
            
            //_location.X += dx;
            //_location.Y += dy;
            for (int i = 0; i < _points.Count; i++)
                _points[i] = new Seal.Location(_points[i].X + dx, _points[i].Y + dy);
        }
        public event EventHandler<LocationEventsArgs> FigureMoved = (s, e) => { };
        public void OnFigureMove(object sender, LocationEventsArgs e)
        {
            if (FigureMoved != null)
            {
                FigureMoved(sender, e);
            }
        }
        private Location getLocation()
        {
            float x = _points[0].X;
            float y = _points[0].Y;
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i].X < x)
                    x = _points[i].X;
                if (_points[i].Y < y)
                    y = _points[i].Y;
            }
            return new Location(x, y);
        }

    }
}

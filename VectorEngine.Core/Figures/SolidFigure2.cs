using System;
using System.Collections.Generic;
using System.Linq;
using Seal.Geometries;

namespace Seal.Figures
{
    public class SolidFigure2 : Figure, ILineEndable,IMarkerable ,IMoveable, IScaleable
    {
        private readonly IFilledGeometry geometry;
        private Location _location;
        public SolidFigure2(IFilledGeometry geometry)
        {
            if(geometry==null)
            {
                throw new ArgumentNullException();
            }
            this.geometry = geometry;
        }

        public override bool IsPointInside(ref SharpDX.Point p)
        {
            return geometry.Contains(p);
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            dc.SolidBrush.Color = SharpDX.Color.White;
            geometry.Draw(dc, this.Location);
        }

        public SharpDX.Size2F Size
        {
            get
            {
                return geometry.Size;
            }
            set
            {
                geometry.Size = value;
            }
        }

        public void Scale(float scaleX, float scaleY)
        {
            this.Size = new SharpDX.Size2F(this.Size.Width*scaleX, this.Size.Height*scaleY);
        }

        public SharpDX.RectangleF Bounds
        {
            get { return new SharpDX.RectangleF(this.Location.X,this.Location.Y, Size.Width, Size.Height );}
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location =value;
            }
        }

        public void Offset(float dx, float dy)
        {
             _location.X += dx;
            _location.Y += dy;
                FigureMoved(this, new LocationEventsArgs(Location.X, Location.Y));
        }

        public event EventHandler<LocationEventsArgs> FigureMoved = (s, e) => { };

        public void OnFigureMove(object sender, LocationEventsArgs e)
        {
            FigureMoved(null, new LocationEventsArgs(this.Location.X, this.Location.Y));
        }

        public SharpDX.Vector2 LineEnd
        {
            get
            {
                SharpDX.Vector2 v = new SharpDX.Vector2();
                v.X = Location.X + geometry.Size.Width / 2;
                v.Y = Location.Y + geometry.Size.Height / 2;
                return v;
            }
        }

        public LinkedList<Marker> CreateMarkers()
        {
            LinkedList<Marker> markers = new LinkedList<Marker>();
            Marker m = new SizeMarker();
            m.targetFigure = this;
            markers.AddLast(m);
            return markers;
        }
    }
}

using System;
using System.Collections.Generic;
using Seal.Geometries;

namespace Seal.Figures
{
    public class GeometryFigure : Figure, ILineEndable, IMarkerable, IMoveable, IScaleable, IFillColorable
    {
        private readonly IFilledGeometry geometry;
        private Location _location;
        private SharpDX.Color4 color;
        private SharpDX.Color4 fillColor;

        public GeometryFigure(IFilledGeometry geometry)
        {
            if (geometry == null)
            {
                throw new ArgumentNullException();
            }
            this.geometry = geometry;
            fillColor = SharpDX.Color.White;
            color = SharpDX.Color.Black;
            StrokeWidth = 1;
        }

        public override bool IsPointInside(ref SharpDX.Point p)
        {
            return geometry.Contains(ref p);
        }

        public override void Draw(Drawing.DrawingContext dc)
        {
            dc.StrokeBrush.Color = color;
            dc.SolidBrush.Color = fillColor;
            geometry.Draw(dc, this.Location, StrokeWidth);
        }

        public Size Size
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
            this.Size = new Size(this.Size.Width * scaleX, this.Size.Height * scaleY);
        }

        public SharpDX.RectangleF Bounds
        {
            get { return new SharpDX.RectangleF(this.Location.X, this.Location.Y, Size.Width, Size.Height); }
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
            _location.X += dx;
            _location.Y += dy;
            FigureMoved(this, new LocationEventsArgs(Location.X, Location.Y));
        }

        public event EventHandler<LocationEventsArgs> FigureMoved = (s, e) => { };

        public void OnFigureMove(object sender, LocationEventsArgs e)
        {
            FigureMoved(null, new LocationEventsArgs(this.Location.X, this.Location.Y));
        }

        public Location LineEnd
        {
            get
            {
                Location v = new Location();
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

        public SharpDX.Color4 FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                fillColor = value;
            }
        }

        public SharpDX.Color4 Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }


        public int StrokeWidth
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seal.Images;
namespace Seal.Figures
{
    public  class ImageFigure : Figure, IMoveable, IScaleable, IMarkerable
    {
        private IImage image;
        private Location _location;

        private Size drawingSize;

        public ImageFigure(IImage image)
        {
            if (image == null) throw new ArgumentNullException();
            this.image = image;
            drawingSize = image.Size;
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
        public LinkedList<Marker> CreateMarkers()
        {
            LinkedList<Marker> markers = new LinkedList<Marker>();
            Marker m = new SizeMarker();
            m.targetFigure = this;
            markers.AddLast(m);
            return markers;
        }
        public override void Draw(Drawing.DrawingContext dc)
        {
            var kx = drawingSize.Width/image.Size.Width;
            var ky = drawingSize.Height / image.Size.Height;
            dc.Scale(kx, ky);
            dc.Translate(_location.X, _location.Y);
            image.Draw(dc, Location);
            dc.IdentityTransform();
        }
        public void Offset(float dx, float dy)
        {
            _location.X += dx;
            _location.Y += dy;
            FigureMoved(this, new LocationEventsArgs(Location.X, Location.Y));
        }
        public override bool IsPointInside(ref SharpDX.Point p)
        {
            var rect = new SharpDX.RectangleF(Location.X, Location.Y, drawingSize.Width, drawingSize.Height);
            return rect.Contains(p);
        }


        public event EventHandler<LocationEventsArgs> FigureMoved = (s, e) => { };

        public void OnFigureMove(object sender, LocationEventsArgs e)
        {
            FigureMoved(sender, e);
        }

        public SharpDX.RectangleF Bounds
        {
            get
            {
                return new SharpDX.RectangleF(this.Location.X, this.Location.Y,drawingSize.Width, drawingSize.Height);
            }
        }

        public Size Size
        {
            get
            {
                return drawingSize;
            }
            set
            {
                drawingSize = value;

            }
        }

        public void Scale(float scaleX, float scaleY)
        {
            drawingSize.Width *= scaleX;
            drawingSize.Height *= scaleY;
        }
    }
}

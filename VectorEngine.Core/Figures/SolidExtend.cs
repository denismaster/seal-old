using System;
using System.Collections.Generic;
using SharpDX;
using SharpDX.Direct2D1;
namespace Seal2D.Core.Figures
{
    public class SolidExtend : SolidFigure, IMarkerable, IScaleable
    {
        private SolidFigure _figure;

        public SolidExtend(SolidFigure f)
        {
            _figure = f;
        }

        public Figure Figure
        {
            get
            {
                return _figure;
            }
        }
        public SharpDX.Size2F Size
        {
            get { return new Size2F(_figure.Geometry.GetBounds().Width, _figure.Geometry.GetBounds().Height); }
            set
            {
                Size2F oldSize = new Size2F(_figure.Geometry.GetBounds().Width, _figure.Geometry.GetBounds().Height);
                Size2F newSize = new Size2F(Math.Max(1, value.Width), Math.Max(1, value.Height));
                //коэффициент шкалировани по x
                float kx;
                float ky;
                if (oldSize.Width != 0 || oldSize.Height != 0)
                {
                    kx = newSize.Width / oldSize.Width;
                    //коэффициент шкалировани по y
                    ky = newSize.Height / oldSize.Height;
                }
                else
                {
                    kx = newSize.Width;
                    ky = newSize.Height;
                }
                Scale(kx, ky);
            }
        }
        public override RectangleF Bounds
        {
            get
            {
                return _figure.Bounds;
            }
        }
        public override Point Location
        {
            get
            {
                return _figure.Location;
            }
            set
            {
                _figure.Location = value;
            }
        }
        public override bool IsPointInside(Point p)
        {
            return _figure.IsPointInside(p);
        }
        public override void Offset(int dx, int dy)
        {
            _figure.Offset(dx, dy);
        }
        public  ICollection<Marker> CreateMarkers()
        {
            LinkedList<Marker> markers = new LinkedList<Marker>();
            Marker m = new SizeMarker();
             m.targetFigure = this;
            markers.AddLast(m);
            return markers;
        }
        public virtual void Scale(float scaleX, float scaleY)
        {
            //var TextRect = _figure.TextRect;
            Matrix m = Matrix.Scaling(scaleX, scaleY, 1);
            _figure.Geometry = new TransformedGeometry(SolidFigure.D2DFactory, this._figure.Geometry, m);
            //TextRect = new RectangleF(TextRect.Left * scaleX, TextRect.Top * scaleY, TextRect.Width + scaleX, TextRect.Height + scaleY);
            //if (TextPath != null)
            //{
            //    TextPath.MaxWidth += TextRect.Width;
            //    TextPath.MaxHeight += TextRect.Height;// = new RectangleF(TextRect.Left /* scaleX*/, TextRect.Top/* scaleY*/, TextRect.Width * scaleX, TextRect.Height * scaleY);
            //}
            OnFigureMove(this, null);
        }
        public virtual void OnFigureMove(object sender, LocationEventsArgs e)
        {
            if (FigureMoved != null)
            {
                FigureMoved(sender, e);
            }
        }
        public event EventHandler<LocationEventsArgs> FigureMoved;
    }
}

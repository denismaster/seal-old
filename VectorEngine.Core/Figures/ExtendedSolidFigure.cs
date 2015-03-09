using System;
using System.Collections.Generic;
using SharpDX;
using SharpDX.Direct2D1;
namespace Seal2D.Core.Figures
{
    public class ExtendedSolidFigure :SolidFigure, IMarkerable,IScaleable, IMoveable
    {
        public ExtendedSolidFigure(SolidFigure f)
        {
            this.Figure = f;
        }
        public SolidFigure Figure
        {
            get;
            set;
        }
        public SharpDX.Size2F Size
        {
            get { return new Size2F(Figure.Geometry.GetBounds().Width, Figure.Geometry.GetBounds().Height); }
            set
            {
                Size2F oldSize = new Size2F(Figure.Geometry.GetBounds().Width, Figure.Geometry.GetBounds().Height);
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
                return Figure.Bounds;
            }
        }
        public override Point Location
        {
            get
            {
                return Figure.Location;
            }
            set
            {
                Figure.Location = value;
            }
        }
        public void Offset(int dx, int dy)
        {
            var l = Location;
            l.X += dx;
            l.Y += dy;
            if (l.X < 0)
            {
                l.X = 0;
            }
            if (l.Y < 0)
                l.Y = 0;
            Location = l;
            if (FigureMoved != null)
                FigureMoved(this, new LocationEventsArgs(Figure.Location.X, Figure.Location.Y));
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
            //var TextRect = Figure.TextRect;
            Matrix m = Matrix.Scaling(scaleX, scaleY, 1);
            Figure.Geometry = new TransformedGeometry(D2DFactory, this.Figure.Geometry, m);
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

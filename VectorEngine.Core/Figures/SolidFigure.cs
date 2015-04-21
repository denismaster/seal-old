using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Seal.Figures;
using SharpDX;

namespace Seal.Figures
{
    [Serializable]
    public abstract class SolidFigure : Figure, ILineEndable, IBoundable, IColorable, IMoveable
    {
        [XmlIgnore]
        [JsonIgnore]
        public const int defaultSize = 25;
        private SharpDX.Color4 _brushColor = SharpDX.Color.White;
        private Location _location;
        [XmlIgnore]
        [JsonIgnore]
        public virtual SharpDX.Direct2D1.Geometry Geometry
        {
            get;
            set;
        }
        public virtual SharpDX.Color4 Color
        {
            get
            {
                return _brushColor;
            }
            set
            {
                _brushColor = value;
            }
        }
        [JsonProperty(TypeNameHandling=TypeNameHandling.None)]
        public virtual Location Location
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
        [XmlIgnore]
        [JsonIgnore]
        public virtual SharpDX.Vector2 LineEnd
        {
            get
            {
                Vector2 v = new Vector2();
                v.X = Location.X + Geometry.GetBounds().Width / 2;
                v.Y = Location.Y + Geometry.GetBounds().Height / 2;
                return v;
            }
        }
        [XmlIgnore]
        [JsonIgnore]
        public virtual SharpDX.RectangleF Bounds
        {
            get
            {
                RectangleF bounds = Geometry.GetBounds();
                return new RectangleF(bounds.Left + Location.X, bounds.Top + Location.Y, bounds.Width, bounds.Height);
            }
        }
        public override bool IsPointInside(ref Point p)
        {
            var dx = Convert.ToInt32(System.Math.Round(Location.X));
            var dy = Convert.ToInt32(System.Math.Round(Location.Y));
            Point here = new Point(p.X - dx, p.Y - dy);
            if (Geometry != null)
                return Geometry.StrokeContainsPoint(here, 1) || Geometry.FillContainsPoint(here);
            else
                return false;
        }
        public virtual void Offset(float dx, float dy)
        {
            _location.X += dx;
            _location.Y += dy;
                FigureMoved(this, new LocationEventsArgs(Location.X, Location.Y));
        }
        public override void Draw(Drawing.DrawingContext dc)
        {
            try
            {
                dc.D2DTarget.Transform = Matrix.Translation(this._location.X, this._location.Y, 0);
                dc.SolidBrush.Color = this.Color;
                dc.D2DTarget.FillGeometry(this.Geometry, dc.SolidBrush);
                dc.D2DTarget.DrawGeometry(this.Geometry, dc.StrokeBrush, 1);
                //if (this.CompiledText != null && this.TextRect.Width >= this.CompiledText.Metrics.WidthIncludingTrailingWhitespace)
                //    g.DrawTextLayout(this.TextRect.TopLeft, this.CompiledText, dc.StrokeBrush);
            }
            finally
            {
                dc.D2DTarget.Transform = SharpDX.Matrix.Identity;
            }
        }
        public virtual void OnFigureMove(object sender, LocationEventsArgs e)
        {
                FigureMoved(sender, e);
        }
        public event EventHandler<LocationEventsArgs> FigureMoved = (s,e) => { };
        
    }
}

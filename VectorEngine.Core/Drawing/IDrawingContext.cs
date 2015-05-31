using System;
namespace Seal.Drawing
{
    public interface IDrawingContext
    {
        void Clear(SharpDX.Color color);
        void DrawEllipse(SharpDX.Direct2D1.Ellipse ellipse, SharpDX.Vector2 where, int strokeWidth = 1);
        void DrawLine(SharpDX.Vector2 from, SharpDX.Vector2 to, int strokeWidth = 1);
        void DrawRectangle(SharpDX.RectangleF rect, SharpDX.Vector2 where, int strokeWidth = 1);
        void IdentityTransform();
        void Scale(float kx, float ky);
        void Translate(float dx, float dy);
        SharpDX.Color StrokeColor
        {
            get;
            set;
        }
        SharpDX.Color FillColor
        {
            get;
            set;
        }
        SharpDX.Color MarkerColor
        {
            get;
            set;
        }
    }
}

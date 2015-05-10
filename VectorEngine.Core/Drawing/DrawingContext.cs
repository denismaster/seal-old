using System;
using SharpDX;
using Direct2D=SharpDX.Direct2D1;
using DW=SharpDX.DirectWrite; 

namespace Seal.Drawing
{
    public class DrawingContext : Seal.Drawing.IDrawingContext
    {
        public void Clear(Color color)
        {
            D2DTarget.Clear(color);
        }
        public void Scale(float kx, float ky)
        {
            D2DTarget.Transform *= Matrix.Scaling(kx, ky, 1);
        }
        public void Translate(float dx, float dy)
        {
            D2DTarget.Transform *= Matrix.Translation(dx, dy, 0);
        }
        public void IdentityTransform()
        {
            D2DTarget.Transform = Matrix.Identity;
        }
        public void DrawRectangle(RectangleF rect, Vector2 where, int strokeWidth=1)
        {
            D2DTarget.FillRectangle(rect, SolidBrush);
            D2DTarget.DrawRectangle(rect, StrokeBrush,strokeWidth);
        }
        public void DrawLine(Vector2 from, Vector2 to, int strokeWidth = 1)
        {
            D2DTarget.DrawLine(from, to, StrokeBrush, strokeWidth);
        }
        public void DrawEllipse(Direct2D.Ellipse ellipse, Vector2 where,int strokeWidth = 1)
        {
            D2DTarget.FillEllipse(ellipse, SolidBrush);
            D2DTarget.DrawEllipse(ellipse, StrokeBrush, strokeWidth);
        }
        public DrawingContext(Direct2D.RenderTarget g)
        {
            this.D2DTarget = g;
            StrokeBrush = new Direct2D.SolidColorBrush(g, Color.Black);
            SolidBrush = new Direct2D.SolidColorBrush(g, Color.White);
            MarkerBrush = new Direct2D.SolidColorBrush(g, Color.White);
        }
        public Direct2D.RenderTarget D2DTarget
        {
            get;
            set;
        }

        public Direct2D.SolidColorBrush StrokeBrush
        {
            get;
            set;
        }
        public Direct2D.SolidColorBrush SolidBrush
        {
            get;
            set;
        }
        public Direct2D.SolidColorBrush MarkerBrush;
    }
}

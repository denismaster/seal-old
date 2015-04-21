using System;
using SharpDX;
using D2D=SharpDX.Direct2D1;
using DW=SharpDX.DirectWrite; 

namespace Seal.Drawing
{
    public class DrawingContext
    {
        public void Clear(Color color)
        {
            D2DTarget.Clear(color);
        }
        public void DrawRectangle(RectangleF rect, Vector2 where)
        {
            D2DTarget.FillRectangle(rect, SolidBrush);
            D2DTarget.DrawRectangle(rect, StrokeBrush);
        }
        public void DrawLine(Vector2 from, Vector2 to)
        {
            D2DTarget.DrawLine(from, to, StrokeBrush);
        }
        public void DrawEllipse(D2D.Ellipse ellipse, Vector2 where)
        {
            D2DTarget.FillEllipse(ellipse, SolidBrush);
            D2DTarget.DrawEllipse(ellipse, StrokeBrush);
        }
        public DrawingContext(D2D.RenderTarget g)
        {
            this.D2DTarget = g;
            StrokeBrush = new D2D.SolidColorBrush(g, Color.Black);
            SolidBrush = new D2D.SolidColorBrush(g, Color.White);
            MarkerBrush = new D2D.SolidColorBrush(g, Color.White);
        }
        public D2D.RenderTarget D2DTarget
        {
            get;
            set;
        }

        public D2D.SolidColorBrush StrokeBrush
        {
            get;
            set;
        }
        public D2D.SolidColorBrush SolidBrush
        {
            get;
            set;
        }
        public D2D.SolidColorBrush MarkerBrush;
    }
}

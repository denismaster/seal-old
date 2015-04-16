using System;
using SharpDX;
using D2D=SharpDX.Direct2D1;
using DW=SharpDX.DirectWrite; 

namespace Seal2D.Core.Drawing
{
    public class DrawingContext
    {
        public void DrawRectangle(RectangleF rect, Vector2 where)
        {
            D2DTarget.FillRectangle(rect, SolidBrush);
            D2DTarget.DrawRectangle(rect, StrokeBrush);
        }
        public void DrawLine(Vector2 from, Vector2 to)
        {
            D2DTarget.DrawLine(from, to, StrokeBrush);
        }
        public DrawingContext(D2D.RenderTarget g)
        {
            this.D2DTarget = g;
            StrokeBrush = new D2D.SolidColorBrush(g, Color.Black);
            SolidBrush = new D2D.SolidColorBrush(g, Color.White);
            MarkerBrush = new D2D.SolidColorBrush(g, Color.Red);
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

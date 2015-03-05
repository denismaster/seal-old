using System;
using SharpDX;
using D2D=SharpDX.Direct2D1;
using DW=SharpDX.DirectWrite; 

namespace Seal2D.Core.Drawing
{
    public class DrawingContext
    {
        public DrawingContext(D2D.RenderTarget g)
        {
            this.D2DTarget = g;
            StrokeBrush = new D2D.SolidColorBrush(g, Color.Black);
            SolidBrush = new D2D.SolidColorBrush(g, Color.White);
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
    }
}

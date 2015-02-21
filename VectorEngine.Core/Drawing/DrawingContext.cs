using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using D2D=SharpDX.Direct2D1;
using DW=SharpDX.DirectWrite; 

namespace VectorEngine.Core.Drawing
{
    public class DrawingContext
    {
        public D2D.RenderTarget D2DTarget
        {
            get;
            set;
        }

        public D2D.SolidColorBrush PenBrush
        {
            get;
            set;
        }
        public D2D.LinearGradientBrush GradientBrush
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

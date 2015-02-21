using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;
using SharpDX;

namespace VectorEngine.Core.Figures
{
    public interface IBoundable
    {
        RectangleF Bounds
        {
            get;
        }
        //Размер фигуры
        Size2F Size
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;

namespace VectorEngine.Core.Figures
{
    public abstract class Figure : VectorObject
    {
        public abstract bool IsPointInside(Point p);

        public static Factory D2DFactory
        {
            get;
            set;
        }
    }
}

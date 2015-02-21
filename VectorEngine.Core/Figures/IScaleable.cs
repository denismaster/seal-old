using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEngine.Core.Figures
{
    public interface IScaleable : IBoundable 
    {
        void Scale(float scaleX, float scaleY);
    }
}

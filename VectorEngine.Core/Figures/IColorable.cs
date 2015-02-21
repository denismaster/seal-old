using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
namespace VectorEngine.Core.Figures
{
    public interface IColorable
    {
        Color4 Color
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
namespace Seal.Figures
{
    public interface IFillColorable:IColorable
    {
        Color4 FillColor
        {
            get;
            set;
        }
    }
}

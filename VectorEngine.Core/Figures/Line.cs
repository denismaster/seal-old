using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Seal2D.Core.Figures
{
    public abstract class LineBase : Figure
    {
        public ILineEndable From
        {
            get;
            set;
        }

        public ILineEndable To
        {
            get;
            set;
        }
    }
}

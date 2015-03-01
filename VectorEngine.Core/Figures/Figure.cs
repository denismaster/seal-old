using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal2D.Core.Figures
{
    public abstract class Figure : FigureBase
    {
        public abstract ICollection<Marker> CreateMarkers();
    }
}

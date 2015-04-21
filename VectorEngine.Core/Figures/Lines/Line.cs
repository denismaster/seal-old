using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Seal.Figures
{
    public abstract class LineBase : Figure, IMarkerable
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
        public abstract LinkedList<Marker> CreateMarkers();
    }
    public interface IPointControllable
    {
        SharpDX.Vector2 GetPoint(int index);
    }
}

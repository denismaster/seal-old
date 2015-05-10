using System.Collections.Generic;
namespace Seal.Figures
{
    public abstract class LineBase : Figure, IMarkerable, IColorable
    {
        private SharpDX.Color4 _lineColor = SharpDX.Color.Black;
        private int _strokeWidth = 1;

        public LineBase(ILineEndable From, ILineEndable To)
        {
            if (From == null ||To == null)
            {
                throw new System.ArgumentNullException();
            }
            this.From = From;
            this.To = To;
        }
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
        public SharpDX.Color4 Color
        {
            get
            {
                return _lineColor;
            }
            set
            {
                _lineColor = value;
            }
        }
        public int StrokeWidth
        {
            get
            {
                return _strokeWidth;
            }
            set
            {
                _strokeWidth = value;
            }
        }
        public abstract LinkedList<Marker> CreateMarkers();
    }
    public interface IPointControllable
    {
        Location GetPoint(int index);
    }
}

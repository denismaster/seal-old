using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;
using SharpDX;
namespace VectorEngine.Core.Figures
{
    public class LocationEventsArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
        public LocationEventsArgs(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
    public interface IMoveable
    {
        Point Location
        {
            get;
            set;
        }
        void Offset(int dx, int dy);

        event EventHandler<LocationEventsArgs> FigureMoved;

        void OnFigureMove(object sender, LocationEventsArgs e);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;
using SharpDX;
using Seal;
namespace Seal.Figures
{
    public class MarkerEventArgs : LocationEventsArgs
    {
        public int Index
        {
            get;
            set;
        }
        public MarkerEventArgs(float X, float Y, int Index)
            : base(X, Y)
        {
            this.X = X;
            this.Y = Y;
            this.Index = Index;
        }
    }
    public class LocationEventsArgs : EventArgs
    {
        public float X { get; set; }
        public float Y { get; set; }
        public LocationEventsArgs(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
    public interface IMoveable
    {
        Location Location
        {
            get;
            set;
        }
        void Offset(float dx, float dy);

        event EventHandler<LocationEventsArgs> FigureMoved;

        void OnFigureMove(object sender, LocationEventsArgs e);
    }
}

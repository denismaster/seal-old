using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;
using SharpDX;
using Seal2D.Core;
namespace Seal2D.Core.Figures
{
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

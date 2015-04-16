using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal2D.Core.Figures
{
    public abstract class ImageFigure : Figure, IMoveable
    {
        public Location Location
        {
            get;
            set;
        }

        public void Offset(float dx, float dy)
        {
            throw new NotImplementedException();
        }



        public event EventHandler<LocationEventsArgs> FigureMoved;

        public void OnFigureMove(object sender, LocationEventsArgs e)
        {
            if (FigureMoved != null)
                FigureMoved(sender, e);
        }
    }
}

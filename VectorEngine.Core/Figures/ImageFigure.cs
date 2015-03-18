using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seal2D.Core.Figures
{
    public abstract class ImageFigure : Figure, IMoveable
    {
        public SharpDX.Point Location
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Offset(int dx, int dy)
        {
            throw new NotImplementedException();
        }
    }
}

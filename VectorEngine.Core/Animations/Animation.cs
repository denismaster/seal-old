using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seal2D.Core.Figures;
namespace Seal2D.Core.Animations
{
    public abstract class Animation : Seal2D.Core.Figures.VectorObject
    {
        public Animation(Figure f)
        {
            if(f==null)
            {
                throw new ArgumentNullException();
            }
            Target = f;
        }
        public Figure Target;
        public abstract void Execute();

    }
}

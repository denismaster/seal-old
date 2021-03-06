﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seal.Figures;
namespace Seal.Animations
{
    public abstract class Animation : Seal.Figures.VectorObject
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

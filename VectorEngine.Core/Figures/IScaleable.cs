﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal2D.Core.Figures
{
    public interface IScaleable : IBoundable 
    {
        Size2F Size
        {
            get;
            set;
        }
        void Scale(float scaleX, float scaleY);
    }
}

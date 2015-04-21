﻿using System;
using SharpDX;
namespace Seal.Figures
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

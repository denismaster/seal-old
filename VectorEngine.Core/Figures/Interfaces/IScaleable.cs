using System;
using SharpDX;
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

using System;
using Seal.Drawing;
namespace Seal.Geometries
{
    public interface IGeometry
    {
        bool Contains(ref SharpDX.Point p);
        void Draw(DrawingContext dc, SharpDX.Vector2 where, int strokeWidth=1);
    }
    public interface IFilledGeometry:IGeometry
    {
        Size Size
        {
            get;
            set;
        }
    }
    
}

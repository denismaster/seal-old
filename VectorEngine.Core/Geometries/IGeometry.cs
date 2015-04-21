using System;
using Seal.Drawing;
namespace Seal.Geometries
{
    public interface IGeometry
    {
        bool Contains(SharpDX.Point p);
        void Draw(DrawingContext dc, SharpDX.Vector2 where);
    }
    public interface IFilledGeometry:IGeometry
    {
        SharpDX.Size2F Size
        {
            get;
            set;
        }
    }
    
}

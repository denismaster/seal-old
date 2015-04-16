using System;
using Seal2D.Core.Drawing;
namespace Seal2D.Core.Geometries
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

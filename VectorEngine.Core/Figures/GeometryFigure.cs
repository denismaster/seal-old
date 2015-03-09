using SharpDX.Direct2D1;
using SharpDX;
namespace Seal2D.Core.Figures
{
    public class GeometryFigure : SolidFigure
    {
       public GeometryFigure()
        {
           this.Geometry = new RectangleGeometry(D2DFactory,new Rectangle(0,0,20,20));
        }
    }
}

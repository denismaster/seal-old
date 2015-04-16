using System;
using System.Text;
using Newtonsoft.Json;
namespace Seal2D.Core.Figures
{
    [Serializable]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Objects)]
    public abstract class Figure : Seal2D.Core.Figures.VectorObject
    {
        public static SharpDX.Direct2D1.Factory D2DFactory
        {
            get;
            set;
        }

        public abstract bool IsPointInside(SharpDX.Point p);

        public abstract void Draw(Drawing.DrawingContext dc);
        
    }
}

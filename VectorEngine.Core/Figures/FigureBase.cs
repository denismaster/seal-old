using System;
using System.Text;
using Newtonsoft.Json;
namespace Seal.Figures
{
    [Serializable]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Objects)]
    public abstract class Figure : Seal.Figures.VectorObject
    {
        public abstract bool IsPointInside(ref SharpDX.Point p);

        public abstract void Draw(Drawing.IDrawingContext dc);
        
    }
}

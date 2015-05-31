
namespace Seal.Text
{
    public interface IText
    {
        string Value
        {
            get;
            set;
        }
        void Draw(Location location,Drawing.IDrawingContext dc);
    }
}

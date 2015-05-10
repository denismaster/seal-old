
namespace Seal.Images
{
    public interface IImage
    {
        Size Size
        {
            get;
            set;
        }
        void Draw(Seal.Drawing.DrawingContext dc, Location where);
    }
}

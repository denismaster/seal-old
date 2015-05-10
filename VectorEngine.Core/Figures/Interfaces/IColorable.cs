using SharpDX;
namespace Seal.Figures
{
    public interface IColorable
    {
        Color4 Color
        {
            get;
            set;
        }
        int StrokeWidth
        {
            get;
            set;
        }
    }
}

using SharpDX;
namespace Seal.Figures
{
    public interface IColorable
    {
        Color Color
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

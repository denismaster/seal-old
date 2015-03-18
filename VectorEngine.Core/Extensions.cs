using System;
using SharpDX;
namespace Seal2D.Core.Figures
{
    public static class Extensions
    {
        public static RectangleF Absolute(this RectangleF r)
        {
            var width = r.Width;
            var height = r.Height;
            if (width > 0 && height > 0) return r;
            if (width < 0 && height < 0) return new RectangleF(r.X+width,r.Y+height, -width, -height);
            if (width < 0) return new RectangleF(r.X + width, r.Y, -width, height);
            if (height < 0) return new RectangleF(r.X, r.Y + height, width, -height);
            else return r;
        }
    }
}

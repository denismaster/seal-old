using System;
using SharpDX;
namespace Seal2D.Core.Figures
{
    public static class Extensions
    {
        #region RectangleF methods

        public static RectangleF Absolute(this RectangleF r)
        {
            if (r.Width < 0)
            {
                r.Width = -r.Width;
                r.X -= r.Width;
            }
            if (r.Height < 0)
            {
                r.Height = -r.Height;
                r.Y -= r.Height;
            }
            return r;
        }
        #endregion
    }
}

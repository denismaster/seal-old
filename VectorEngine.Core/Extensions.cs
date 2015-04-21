using System;
using SharpDX;
namespace Seal.Figures
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
namespace Seal
{
    public static class Math
    {
        public static bool IsPointInSegment(ref SharpDX.Point p, ref Location From, ref Location To)
        {
            var p1 = From;
            var p2 = To;

            var dx = p2.X - p1.X;
            var dy = p2.Y - p1.Y;

            if (dx == 0) return (p.Y >= p1.Y && p.Y <= p2.Y);
            if (dy == 0) return (p.X >= p1.X && p.Y <= p2.X);
            else
            {
                var s1 = (p.X - p1.X) / dx;
                var s2 = (p.Y - p1.Y) / dy;
                return (System.Math.Abs(s1 - s2) <= 5E-2);
            }
        }

    }
}

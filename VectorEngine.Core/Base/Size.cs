using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal
{
    public struct Size
    {
        public float Width;
        public float Height;

        public static readonly Size Zero = new Size(0,0);

        public Size(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public static implicit operator SharpDX.Size2F(Size size)
        {
            return new SharpDX.Size2F(size.Width, size.Height);
        }
    }
}

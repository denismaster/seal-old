using System;
using SharpDX.Direct2D1;
namespace Seal.Images
{
    public class BitmapImage:IImage
    {
        private readonly Bitmap image;
        public BitmapImage(Bitmap bitmap)
        {
            if(bitmap==null)
            {
                throw new ArgumentNullException();
            }
            image = bitmap;
        }
        public Size Size
        {
            get
            {
                return new Size(image.Size.Width, image.Size.Height);
            }
            set
            {
                //cannot do this action
            }
        }

        public void Draw(Drawing.DrawingContext dc, Location where)
        {
            try
            {
              //  dc.D2DTarget.Transform = SharpDX.Matrix.Translation(where.X, where.Y, 0);
                dc.D2DTarget.DrawBitmap(image, 1, BitmapInterpolationMode.Linear);
              //  dc.D2DTarget.Transform = SharpDX.Matrix.Identity;
            }
            catch
            {
                Console.Write("eerror");
            }
        }
    }
}

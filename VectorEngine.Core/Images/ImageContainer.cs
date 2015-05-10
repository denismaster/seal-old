using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX.DXGI;
using SharpDX;
using Direct2D=SharpDX.Direct2D1;
using WIC= SharpDX.WIC;

namespace Frosya2.Objects
{
    /// <summary>
    /// Класс-контейнер для хранения Bitmap в различных случаях отрисовки.
    /// </summary>
    public class ImageContainer:IDisposable
    {
        #region Свойства
        /// <summary>
        /// Версия Bitmap для отрисовки в файл с помощью WIC
        /// </summary>
        public WIC.Bitmap WicBitmap { get; set; }
        /// <summary>
        /// Версия Bitmap для отрисовки непосредственно на экран
        /// </summary>
        public Direct2D.Bitmap D2DBitmap { get; set; }

        #endregion
        #region Конструкторы
        public ImageContainer(string filename, Direct2D.RenderTarget WicTarget, Direct2D.RenderTarget D2DTarget)
        {
            LoadFromFile(filename, WicTarget, D2DTarget);
        }
        public void Dispose()
        {
            WicBitmap.Dispose();
            D2DBitmap.Dispose();
        }
        
        #endregion
        #region Методы
        private void LoadFromFile(string filename, Direct2D.RenderTarget WicTarget, Direct2D.RenderTarget D2DTarget)
        {
            var factory = new WIC.ImagingFactory();
            // Decode image
            var decoder = new WIC.BitmapDecoder(factory, filename, WIC.DecodeOptions.CacheOnLoad);
            var frameDecode = decoder.GetFrame(0);
            var source = new WIC.BitmapSource(frameDecode.NativePointer);
           
            
            var fc = new WIC.FormatConverter(factory);
            fc.Initialize(
                source,
                SharpDX.WIC.PixelFormat.Format32bppPBGRA,
                SharpDX.WIC.BitmapDitherType.None,
                null,
                0.0f,
                SharpDX.WIC.BitmapPaletteType.Custom
            );
            double dpX = 96.0f;
            double dpY = 96.0f;
            fc.GetResolution(out dpX, out dpY);
            Direct2D.BitmapProperties props = new Direct2D.BitmapProperties(
                new SharpDX.Direct2D1.PixelFormat(SharpDX.DXGI.Format.B8G8R8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Premultiplied));
            WIC.Bitmap bmp = new WIC.Bitmap(factory, fc, WIC.BitmapCreateCacheOption.CacheOnLoad);
            // Формируем изображения
            D2DBitmap = SharpDX.Direct2D1.Bitmap.FromWicBitmap(D2DTarget, fc, props);

            WicBitmap = bmp;
            // Cleanup
            factory.Dispose();
            decoder.Dispose();
            source.Dispose();
            fc.Dispose();
        }
        #endregion

    }
}

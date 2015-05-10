using System;
namespace Seal
{
    public interface ID2D
    {
        SharpDX.Direct2D1.Factory D2DFactory { get; }
        SharpDX.Direct2D1.RenderTarget D2DRenderTarget { get; }
        SharpDX.DirectWrite.Factory DWFactory { get; }
        SharpDX.WIC.ImagingFactory WICFactory { get; }
    }
}

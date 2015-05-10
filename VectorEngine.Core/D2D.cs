using System;
using Direct2D = SharpDX.Direct2D1;
using DW = SharpDX.DirectWrite;
using WIC = SharpDX.WIC;
namespace Seal
{
    public class D2D : Seal.ID2D
    {
        private static D2D _instanse;

        private readonly Direct2D.Factory d2dFactory;
        private readonly Direct2D.RenderTarget d2dRenderTarget;
        private readonly WIC.ImagingFactory wicFactory;
        private readonly DW.Factory dwFactory;

        public Direct2D.Factory D2DFactory
        {
            get { return d2dFactory; }
        }

        public Direct2D.RenderTarget D2DRenderTarget
        {
            get { return d2dRenderTarget; }
        }

        public WIC.ImagingFactory WICFactory
        {
            get { return wicFactory; }
        }

        public DW.Factory DWFactory
        {
            get { return dwFactory; }
        }

        private D2D(Direct2D.Factory d2dFactory, Direct2D.RenderTarget d2dRenderTarget)
        {
            this.d2dFactory = d2dFactory;
            this.d2dRenderTarget = d2dRenderTarget;
            this.wicFactory = new WIC.ImagingFactory();
            this.dwFactory = new DW.Factory();
        }

        public static D2D Instanse
        {
            get
            {
                if(_instanse==null)
                {
                    throw new ArgumentNullException();
                }
                return _instanse;
            }
        }

        public static void Initialize(Direct2D.Factory d2dFactory, Direct2D.RenderTarget d2dRenderTarget)
        {
            if(d2dFactory==null)
            {
                throw new ArgumentNullException("Direct2D Factory");
            }
            if(d2dRenderTarget==null)
            {
                throw new ArgumentNullException("Direct2D Render Target");
            }
            _instanse = new D2D(d2dFactory, d2dRenderTarget);
        }


    }
}

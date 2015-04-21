using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using D3D = SharpDX.Direct3D;
using D3D10 = SharpDX.Direct3D10;
using DXGI = SharpDX.DXGI;
using D2D = SharpDX.Direct2D1;
using DW = SharpDX.DirectWrite;
using WIC = SharpDX.WIC;
namespace Seal
{
    public interface IDeviceManager :IDisposable
    {
        D2D.Factory D2DFactory
        {
            get;
        }
        D2D.RenderTarget D2DTarget
        {
            get;
        }
        DW.Factory DWFactory
        {
            get;
        }
        WIC.ImagingFactory WICFactory
        {
            get;
        }
        Size2 TargetSize
        {
            get;
            set;
        }
        void OnEndDraw();
        void OnStartDraw();
    }
    public class WinFormsDeviceManager : IDeviceManager
    {
        private D2D.Factory _d2dFactory;
        private D2D.WindowRenderTarget _d2dTarget;
        private D2D.FactoryType _factoryType;
        private D2D.DebugLevel _debugLevel;

        private IntPtr Hwnd;
        private Size2 _targetSize;

        private DW.Factory _dwFactory;

        private WIC.ImagingFactory _wicFactory;

        public WinFormsDeviceManager(IntPtr Hwnd)
        {
            this.Hwnd = Hwnd;
            CreateD2DFactory();
            CreateDWFactory();
            CreateWICFactory();
            CreateRenderTarget();
        }
        public void Dispose()
        {
            _d2dTarget.Dispose();
            _dwFactory.Dispose();
            _d2dTarget.Dispose();
            _wicFactory.Dispose();
        }
        private void CreateD2DFactory()
        {
            _factoryType = D2D.FactoryType.MultiThreaded;
            _debugLevel = D2D.DebugLevel.Information;

            _d2dFactory = new D2D.Factory(_factoryType, _debugLevel);

        }
        private void CreateWICFactory()
        {
            _wicFactory = new WIC.ImagingFactory();
        }
        private void CreateDWFactory()
        {
            _dwFactory = new DW.Factory();
        }
        private void CreateRenderTarget()
        {
            D2D.RenderTargetProperties renderTargetProperties = new D2D.RenderTargetProperties()
            {
                Type = D2D.RenderTargetType.Hardware,
                MinLevel = D2D.FeatureLevel.Level_10
            };
            D2D.HwndRenderTargetProperties hwRenderTargetProperties = new D2D.HwndRenderTargetProperties()
            {
                Hwnd = this.Hwnd,
                PixelSize = _targetSize,
                PresentOptions = D2D.PresentOptions.Immediately
            };
            _d2dTarget = new D2D.WindowRenderTarget(_d2dFactory, renderTargetProperties, hwRenderTargetProperties);
        }
        private void ResizeTarget(ref Size2 newSize)
        {
            var renderTarget = _d2dTarget;
            if (renderTarget != null && !renderTarget.IsDisposed)
                renderTarget.Resize(newSize);
        }
        public void OnEndDraw()
        {
            //must be empty
        }
        public void OnStartDraw()
        {
            //must be empty
        }
        public Size2 TargetSize
        {
            get
            {
                return _targetSize;
            }
            set
            {
                _targetSize = value;
                ResizeTarget(ref _targetSize);
            }
        }

        public D2D.Factory D2DFactory
        {
            get
            {
                return _d2dFactory; 
            }
        }
        public D2D.RenderTarget D2DTarget
        {
            get
            {
                return _d2dTarget; 
            }
        }
        public DW.Factory DWFactory
        {
            get
            {
                return _dwFactory; 
            }
        }
        public WIC.ImagingFactory WICFactory
        {
            get
            {
                return _wicFactory; 
            }
        }


    }
 
}

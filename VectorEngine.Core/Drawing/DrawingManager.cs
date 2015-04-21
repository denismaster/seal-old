using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using D2D = SharpDX.Direct2D1;
namespace Seal
{
    public interface IDrawingManager
    {
        IDeviceManager DeviceManager
        {
            get;
        }
        Action<Drawing.DrawingContext> RenderAction
        {
            get;
        }
        void Resize(Size2 s);
        Drawing.DrawingContext GetContext();
        void OnRenderError(Exception s);
        void StartRendering();
    }
    public class DrawingManager : IDrawingManager
    {
        private readonly IDeviceManager _deviceManager;
        private readonly Action<Drawing.DrawingContext> _renderAction;
        public DrawingManager(IDeviceManager deviceManager, Action<Drawing.DrawingContext> renderAction)
        {
            if (deviceManager == null)
            {
                throw new ArgumentNullException();
            }
            if (renderAction == null)
            {
                throw new ArgumentNullException();
            }
            this._deviceManager = deviceManager;
            this._renderAction = renderAction;
        }
        public Action<Drawing.DrawingContext> RenderAction
        {
            get
            {
                return _renderAction;
            }
        }
        public IDeviceManager DeviceManager
        {
            get
            {
                return _deviceManager;
            }
        }
        public Drawing.DrawingContext GetContext()
        {
            return new Drawing.DrawingContext(this.DeviceManager.D2DTarget);
        }
        public void StartRendering()
        {
            var renderTarget = DeviceManager.D2DTarget;
            try
            {
                renderTarget.BeginDraw();
                try
                {
                    _renderAction(this.GetContext());
                }
                catch (Exception ex)
                {
                    OnRenderError(ex);
                }
                finally
                {
                    renderTarget.EndDraw();
                    DeviceManager.OnEndDraw();
                }
            }
            catch (SharpDXException ex)
            {
                if (ex.ResultCode.Code == unchecked((int)0x8899000C))
                {
                    DeviceManager.Dispose();
                }
            }

        }
        public virtual void OnRenderError(Exception ex)
        {

        }
        public void Resize(Size2 s)
        {
            _deviceManager.TargetSize = s;
        }
    }
}

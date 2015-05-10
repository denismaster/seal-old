using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpDX.Direct2D1;
using SharpDX;
using SharpDX.DirectWrite;
using WIC = SharpDX.WIC;
namespace Seal2D.Control
{
    public abstract class D2DCanvas : D2DLayer
    {
        
        public D2DCanvas()
        {
        }
        public RenderTarget RenderTarget
        {
            get
            {
                return this.renderTarget;
            }
        }
        protected override void OnCreateRenderObjects()
        {
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }
        protected override void OnDisposeRenderObjects()
        {
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }
        protected override void OnUpdate()
        {

        }
        protected override void OnRender()
        {
            renderTarget.Clear(Color.White);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }
    }
}

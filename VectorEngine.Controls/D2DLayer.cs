﻿using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIC=SharpDX.WIC;
namespace Seal2D.Control
{
    public abstract class D2DLayer : System.Windows.Forms.Control
    {
        protected SharpDX.Direct2D1.FactoryType FactoryType { get; set; }
        protected DebugLevel DebugLevel { get; set; }
        private WIC.ImagingFactory wicFactory;
        private WicRenderTarget wicRenderTarget;

        public RenderTargetProperties renderTargetProperties = new RenderTargetProperties()
        {
            Type = RenderTargetType.Hardware,
            MinLevel = FeatureLevel.Level_10
        };

        public D2DLayer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserPaint, true);
            FactoryType = SharpDX.Direct2D1.FactoryType.MultiThreaded;
            DebugLevel = SharpDX.Direct2D1.DebugLevel.Information;
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!DesignMode)
            {
                D2DFactory = new SharpDX.Direct2D1.Factory(FactoryType, DebugLevel);
                CreateRenderObjects();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Disposing)
            {
                DisposeRenderObjects();
                if (D2DFactory != null)
                {
                    D2DFactory.Dispose();
                    D2DFactory = null;
                }
            }
            base.Dispose(disposing);
        }
        protected override void OnResize(EventArgs e)
        {
            try
            {
                if (renderTarget != null && !renderTarget.IsDisposed)
                    renderTarget.Resize(new SharpDX.Size2(Width, Height));
                
            }
            finally
            {
                base.OnResize(e);
            }
        }

        //Render Objects
        private bool RenderObjectsCreated;
        protected SharpDX.Direct2D1.Factory D2DFactory { get; set; }
        protected WindowRenderTarget renderTarget;
        private void CreateRenderObjects()
        {
            HwndRenderTargetProperties hwRenderTargetProperties = new HwndRenderTargetProperties()
            {
                Hwnd = this.Handle,
                PixelSize = new SharpDX.Size2(ClientSize.Width, ClientSize.Height),
                PresentOptions = PresentOptions.Immediately
            };
            renderTarget = new WindowRenderTarget(D2DFactory, renderTargetProperties, hwRenderTargetProperties);
            Seal.D2D.Initialize(this.D2DFactory, this.renderTarget);
            RenderObjectsCreated = true;
            OnCreateRenderObjects();
        }
        protected abstract void OnCreateRenderObjects();
        private void DisposeRenderObjects()
        {
            if (RenderObjectsCreated)
            {
                renderTarget.Dispose();
                renderTarget = null;
                OnDisposeRenderObjects();
                RenderObjectsCreated = false;
            }
        }
        protected abstract void OnDisposeRenderObjects();
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (RenderObjectsCreated)
            {
                StartRendering();
            }
            else
            {
                pe.Graphics.Clear(System.Drawing.Color.CornflowerBlue);
                pe.Graphics.DrawString(Name, Font, Brushes.White, PointF.Empty);
            }
        }
        private void StartRendering()
        {
            try
            {
                if (renderTarget == null)
                    CreateRenderObjects();
                renderTarget.BeginDraw();
                try
                {
                    OnRender();
                }
                catch (Exception ex)
                {
                    OnRenderError(ex);
                }
                finally
                {
                    renderTarget.EndDraw();
                }
            }
            catch (SharpDXException ex)
            {
                if (ex.ResultCode.Code == unchecked((int)0x8899000C))
                {
                    DisposeRenderObjects();
                    CreateRenderObjects();
                    Invalidate();
                }
            }
        }
        protected abstract void OnUpdate();
        protected abstract void OnRender();
        protected virtual void OnRenderError(Exception ex)
        {
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "D2DLayer";
            this.ResumeLayout(false);
        }

        private void D2DStage_Load(object sender, EventArgs e)
        {

        }
    }
}
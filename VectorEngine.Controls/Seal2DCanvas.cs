using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seal.Drawing;
using Seal.Figures;
using Seal.Controllers;
using SharpDX;
namespace Seal2D.Control
{
    public class Seal2DCanvas : D2DCanvas
    {
        //protected Figure draggedFigure;
        private Diagram _diagram;
        public Diagram Diagram
        {
            get
            {
                return _diagram;
            }
            set
            {
                if (value != null)
                {
                    _diagram = value;
                    if(ModeController!=null)
                    ModeController.Diagram = _diagram;
                }
            }

        }
        protected DrawingContext Context
        {
            get;
            set;
        }
        public Controller ModeController
        {
            get
            {
                return _controller;
            }
            set
            {
                _controller = value;
            }
        }
        private Controller _controller = null;
        public Seal2DCanvas()
        {
            Diagram = new ObjectDiagram();
        }
        protected override void OnCreateRenderObjects()
        {
            base.OnCreateRenderObjects();
            Seal.Figures.Figure.D2DFactory = this.D2DFactory;
            Context = new DrawingContext(renderTarget);
            //ObjectManager = new Seal.ObjectFactory();
            _controller = new Seal.Controllers.AddLineController(Diagram);
        }
        protected override void OnRender()
        {
            renderTarget.Clear(Color.White);
            foreach (var f in Diagram.Figures)
            {
                f.Draw(Context);
            }
            if (Diagram.SelectedFigure is Group)
            {
                DrawSelectionRect(Diagram.SelectedFigure as Group);
            }
            else
            {
                IBoundable r = Diagram.SelectedFigure as IBoundable;
                if (r != null)
                {
                    DrawSelectionRect(r);
                }
            }
            _controller.RenderAction(Context);
        }
        private void DrawSelectionRect(Group g)
        {
            foreach (var d in g.Childs)
            {
                IBoundable r = d as IBoundable;
                if (r != null)
                {
                    DrawSelectionRect(r);
                }
            }
        }
        private void DrawSelectionRect(IBoundable r)
        {
            var g = Context.D2DTarget;
            g.Transform = SharpDX.Matrix.Translation(r.Bounds.Left, r.Bounds.Top, 0);
            Context.SolidBrush.Color = Color.DeepSkyBlue;
            g.DrawRectangle(new RectangleF(-2, -2, r.Bounds.Width + 4, r.Bounds.Height + 4), Context.SolidBrush, 1);
            g.Transform = SharpDX.Matrix.Identity;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _controller.MouseUpAction(e);
            Invalidate();
            base.OnMouseUp(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _controller.MouseDownAction(e);
            this.Invalidate();
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {

            _controller.MouseMoveAction(e);
            this.Cursor = _controller.ActiveCursor;
            Invalidate();
            base.OnMouseMove(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            
            _controller.KeyDownAction(e);
            Invalidate();
            base.OnKeyDown(e);
        }
    }
}

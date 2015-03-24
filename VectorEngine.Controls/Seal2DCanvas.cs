using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seal2D.Core.Drawing;
using Seal2D.Core.Figures;
using Seal2D.Control.Controllers;
using SharpDX;
namespace Seal2D.Control
{
    public class Seal2DCanvas : D2DCanvas
    {
        //protected Figure draggedFigure;
        public Diagram Diagram
        {
            get;
            set;
        }
        public DrawingContext Context
        {
            get;
            set;
        }
        protected Seal2D.Core.ObjectFactory ObjectManager
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
            Seal2D.Core.Figures.Figure.D2DFactory = this.D2DFactory;
            Context = new DrawingContext(renderTarget);
            ObjectManager = new Seal2D.Core.ObjectFactory();
            _controller = new SelectionController(Diagram);
        }
        protected override void OnRender()
        {
            renderTarget.Clear(Color.White);
            foreach (var l in Diagram.Lines)
            {
                l.Draw(Context);
            }
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
            Context.SolidBrush.Color = Color.SkyBlue;
            g.DrawRectangle(new RectangleF(-2, -2, r.Bounds.Width + 4, r.Bounds.Height + 4), Context.SolidBrush, 1);
            g.Transform = SharpDX.Matrix.Identity;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _controller.MouseUpAction(e);
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _controller.MouseDownAction(e);
            this.Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {

            _controller.MouseMoveAction(e);
            this.Cursor = _controller.ActiveCursor;
            Invalidate();
        }
    }
}

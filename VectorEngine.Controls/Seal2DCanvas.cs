using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seal2D.Core.Drawing;
using Seal2D.Core.Figures;
using SharpDX;
namespace Seal2D.Control
{
    public class Seal2DCanvas : D2DCanvas
    {
        protected Figure draggedFigure;
        public Diagram Diagram
        {
            get;
            set;
        }
        public Point StartDragPoint
        {
            get;
            set;
        }
        public DrawingContext Context
        {
            get;
            set;
        }
        public Seal2DCanvas()
        {
            Diagram = new ObjectDiagram(); 
        }
        protected override void OnCreateRenderObjects()
        {
            base.OnCreateRenderObjects();
            Seal2D.Core.Figures.Figure.D2DFactory = this.D2DFactory;
            Context = new DrawingContext(renderTarget);
        }
        protected override void OnRender()
        {
            renderTarget.Clear(Color.White);
            foreach(var l in Diagram.Lines)
            {
                l.Draw(Context);
            }
            foreach(var f in Diagram.Figures)
            {
                f.Draw(Context);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            draggedFigure = null;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            draggedFigure = this.Diagram.FindFigureByPoint(new SharpDX.Point(e.Location.X, e.Location.Y));
            if (!(draggedFigure is Marker))
            {
                if (draggedFigure is SolidFigure)
                    draggedFigure = new Seal2D.Core.Figures.ExtendedSolidFigure(draggedFigure as Seal2D.Core.Figures.SolidFigure);

                this.Diagram.SelectedFigure = draggedFigure;
            }
            this.StartDragPoint = new SharpDX.Point(e.Location.X, e.Location.Y);
        }
        protected override  void OnMouseMove(MouseEventArgs e)
        {
            var mouseLocation = new SharpDX.Point(e.Location.X, e.Location.Y);
            if (e.Button == MouseButtons.Left)
            {
                IMoveable q = draggedFigure as IMoveable;
                if (q != null)
                {
                    var dx = mouseLocation.X - this.StartDragPoint.X;
                    var dy = mouseLocation.Y - this.StartDragPoint.Y;
                    q.Offset(dx, dy);
                    //if (!(draggedFigure is EndLineMarker))
                    //    UpdateMarkers();
                    this.Invalidate();
                }
            }
            else
            {
                var figure = this.Diagram.FindFigureByPoint(mouseLocation);
                // this.Tag = figure != null ? figure.ToString() : "null";
                if (figure is Marker)
                    this.Cursor = Cursors.SizeAll;
                else
                    if (figure != null)
                        this.Cursor = Cursors.Hand;
                    else
                        this.Cursor = Cursors.Cross;
            }
            this.StartDragPoint = mouseLocation;
        }
    }
}

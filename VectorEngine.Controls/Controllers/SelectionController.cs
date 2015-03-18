using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using Seal2D.Control;
using Seal2D.Core;
using Seal2D.Core.Figures;
namespace Seal2D.Control.Controllers
{
    public class SelectionController : Controller
    {
        private Point StartDragPoint;
        private Figure draggedFigure;
        private bool isRect = true;
        private RectangleF selectionRect;
        private ICollection<Marker> _markers;
        public SelectionController(Diagram d):base(d)
        {
            _markers = new LinkedList<Marker>();
        }
        private void UpdateMarkers()
        {
            foreach (Marker m in _markers)
                if (draggedFigure != m)//маркер который тащится, обновляется сам
                    m.UpdateLocation();
        }
        private void CreateMarkers()
        {
            if (Diagram.SelectedFigure == null)
                _markers = new LinkedList<Marker>();
            else
            {
                if (null != Diagram.SelectedFigure)
                {
                    IMarkerable m = Diagram.SelectedFigure as IMarkerable;
                    if(m!=null)
                    {
                        _markers = m.CreateMarkers();
                    }

                    UpdateMarkers();
                }
            }
        }

        public override void MouseDownAction(System.Windows.Forms.MouseEventArgs e)
        {
            draggedFigure = this.Diagram.FindFigureByPoint(new SharpDX.Point(e.Location.X, e.Location.Y));
            if (!(draggedFigure is Marker))
            {
                //draggedFigure = ObjectManager.Extend(draggedFigure);
                this.Diagram.SelectedFigure = draggedFigure;
            }
            CreateMarkers();
            this.StartDragPoint = new SharpDX.Point(e.Location.X, e.Location.Y);
            if (!isRect && draggedFigure == null)
            {
                selectionRect.Location = StartDragPoint;
                isRect = true;
            }
        }
        public override void MouseMoveAction(System.Windows.Forms.MouseEventArgs e)
        {
            var mouseLocation = new SharpDX.Point(e.Location.X, e.Location.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var dx = mouseLocation.X - this.StartDragPoint.X;
                var dy = mouseLocation.Y - this.StartDragPoint.Y;
                if (isRect)
                {
                    selectionRect.Width += dx;
                    selectionRect.Height += dy;
                }
                IMoveable q = draggedFigure as IMoveable;
                if (q != null)
                {

                    q.Offset(dx, dy);
                }
                UpdateMarkers();
            }
            else
            {
                var figure = this.Diagram.FindFigureByPoint(mouseLocation);
                if (figure is Marker)
                    this.ActiveCursor = System.Windows.Forms.Cursors.SizeAll;
                else
                    if (figure != null)
                        this.ActiveCursor = System.Windows.Forms.Cursors.Hand;
                    else
                        this.ActiveCursor = System.Windows.Forms.Cursors.Cross;
            }
            this.StartDragPoint = mouseLocation;
        }
        public override void MouseUpAction(System.Windows.Forms.MouseEventArgs e)
        {
            draggedFigure = null;
            if (isRect)
            {
                FindGroupByRect(selectionRect.Absolute());
                selectionRect.Width = 0;
                selectionRect.Height = 0;
                isRect = false;
            }
            //Invalidate();
        }
        private GroupFigure FindGroupByRect(RectangleF r)
        {
            var g = new GroupFigure();
            foreach (var f in Diagram.Figures.OfType<IMoveable>())
            {
                if (r.Contains(f.Location))
                {
                    g.Add(f as Figure);
                }
            }
            // Diagram.Groups.Add(g);
            Diagram.SelectedFigure = g;
            return g;
        }
        public override void RenderAction(Core.Drawing.DrawingContext dc)
        {
            foreach(var m in _markers)
            {
                m.Draw(dc);
            }
            if (isRect)
            {
                dc.SolidBrush.Color = Color.DeepSkyBlue;
                dc.D2DTarget.DrawRectangle(selectionRect, dc.SolidBrush, 2);
            }
        }
    }
}

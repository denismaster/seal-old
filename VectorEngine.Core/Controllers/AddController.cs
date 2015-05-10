using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal.Figures;
namespace Seal.Controllers
{
    public class AddFigureController<T> : Controller where T : Seal.Geometries.IFilledGeometry, new()
    {
        T geometry;
        GeometryFigure figure;
        Size size;
        Location location;

        public AddFigureController(Diagram d)
            : base(d)
        {
            geometry = default(T);
            size = Size.Zero;
        }
        public override void MouseDownAction(System.Windows.Forms.MouseEventArgs e)
        {
            location = new Location(e.X, e.Y);
            geometry = new T();
            figure = new GeometryFigure(geometry);
            figure.Location = location;
            figure.Size = size;
        }
        public override void MouseMoveAction(System.Windows.Forms.MouseEventArgs e)
        {

            if (geometry != null)
            {
               var  size = new Size(e.X - location.X, e.Y - location.Y);
                figure.Size = size;
            }
        }
        public override void MouseUpAction(System.Windows.Forms.MouseEventArgs e)
        {
            if (geometry != null)
            {
                figure.Location = location;
                Diagram.Add(figure);
                geometry = default(T);
                figure = null;
            }
        }
        public override void RenderAction(Drawing.DrawingContext dc)
        {
            figure.Draw(dc);
        }
    }
    public class AddLineController : Controller
    {
        Line line;
        ILineEndable from;
        ILineEndable to;
        public AddLineController(Diagram d)
            : base(d)
        {
            line = null;
            from = null;
            to = null; ;
        }
        public override void MouseDownAction(System.Windows.Forms.MouseEventArgs e)
        {
            SharpDX.Point p = new SharpDX.Point(e.X, e.Y);
            if (from == null)
            {

                from = Diagram.Get(p) as ILineEndable;
                if (from == null)
                {
                    from = new EndLineMarker(Diagram.Get, 0);
                    (from as EndLineMarker).Location = new Location(p.X, p.Y);
                }
                to = new EndLineMarker(Diagram.Get, 1);
                (to as EndLineMarker).Location = new Location(p.X, p.Y);
            }
        }

        public override void MouseUpAction(System.Windows.Forms.MouseEventArgs e)
        {
            var p = new SharpDX.Point(e.X, e.Y);
            var figure = Diagram.Get(p) as ILineEndable;

            if (figure != null)
            {
                line = new Line(from, figure);
            }
            else
                line = new Line(from, to);
            Diagram.Add(line);
            from = null;
            to = null;
            line = null;
        }

        public override void MouseMoveAction(System.Windows.Forms.MouseEventArgs e)
        {
            if (from != null)
            {
                (to as EndLineMarker).Location = new Location(e.X, e.Y);
            }
        }

        public override void KeyDownAction(System.Windows.Forms.KeyEventArgs e)
        {

        }

        public override void RenderAction(Drawing.DrawingContext dc)
        {
            dc.DrawLine(from.LineEnd, to.LineEnd);
        }
    }
}

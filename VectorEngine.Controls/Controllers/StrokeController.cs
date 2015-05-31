using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal;
using Seal.Figures;
using SharpDX;
namespace Seal2D.Control.Controllers
{
    public class StrokeController:Controller
    {
        public StrokeController(Diagram d):base(d)
        {
            this.Diagram = d;
            
        }
        private ICollection<Vector2> points;
        public override void MouseDownAction(System.Windows.Forms.MouseEventArgs e)
        {
            points = new LinkedList<Vector2>();
            points.Add(new Vector2(e.X, e.Y));
        }
        public override void MouseUpAction(System.Windows.Forms.MouseEventArgs e)
        {
            StrokeFigure f = new StrokeFigure(points,Color.Red);
            this.Diagram.Add(f);
            points = null;
        }
        public override void MouseMoveAction(System.Windows.Forms.MouseEventArgs e)
        {
            if(points!=null&&e.Button==System.Windows.Forms.MouseButtons.Left)
            {
                points.Add(new Vector2(e.X, e.Y));
            }

        }
    }
}

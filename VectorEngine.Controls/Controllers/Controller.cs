using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal;
using Seal.Figures;
using Seal2D.Control;
namespace Seal2D.Control.Controllers
{
    public  abstract class Controller
    {
        public Controller(Diagram d)
        {
            this.Diagram = d;
        }
        public Diagram Diagram
        {
            get;
            set;
        }
        public System.Windows.Forms.Cursor ActiveCursor
        {
            get;
            set;
        }
        public virtual void MouseDownAction(System.Windows.Forms.MouseEventArgs e)
        {

        }
        public virtual void MouseUpAction(System.Windows.Forms.MouseEventArgs e)
        {

        }
        public virtual void MouseMoveAction(System.Windows.Forms.MouseEventArgs e)
        {

        }
        public virtual void KeyDownAction(System.Windows.Forms.KeyEventArgs e)
        {

        }
        public virtual void RenderAction(Seal.Drawing.DrawingContext dc)
        {

        }

    }
}

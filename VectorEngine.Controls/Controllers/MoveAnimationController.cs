using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal2D.Core;
using Seal2D.Core.Figures;
namespace Seal2D.Control.Controllers
{
    public class MoveAnimationController:Controller
    {
        public MoveAnimationController(Diagram d):base(d)
        {
            this.Diagram = d;
            
        }
        public override void MouseDownAction(System.Windows.Forms.MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right&&Diagram.SelectedFigure!=null)
            {
                var animation = new Seal2D.Core.Animations.MoveAnimation(this.Diagram.SelectedFigure, e.Location.X, e.Location.Y);
                animation.Execute();
            }
        }
    }
}

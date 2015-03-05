using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal2D.Core.Drawing;
using Seal2D.Core.Figures;
using SharpDX;
namespace Seal2D.Control
{
    public class Seal2DCanvas : D2DCanvas
    {
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
        public Seal2DCanvas()
        {
            Diagram = new ObjectDiagram(); 
        }
        protected override void OnCreateRenderObjects()
        {
            base.OnCreateRenderObjects();
            Seal2D.Core.Figures.FigureBase.D2DFactory = this.D2DFactory;
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
    }
}

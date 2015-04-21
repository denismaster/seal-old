using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seal;
using Seal.Figures;
using Seal.Drawing;
using SharpDX.Direct2D1;
using WeifenLuo.WinFormsUI.Docking;
namespace Seal2D.Win
{
    public partial class formMain : Form
    {
        private Point p;
        private IDeviceManager deviceManager;
        private IDrawingManager drawingManager;
        private Diagram d;
        public formMain()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            drawingManager.StartRendering();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //DockPanel d = new DockPanel();
            //d.Parent = this;
            //d.Dock = DockStyle.Fill;
            //d.Theme = new VS2012LightTheme();
            //new DockContent() { Text = "hello", CloseButton = false }.Show(d, DockState.Document);
            //new DockContent() { Text = "Дерево объектов" }.Show(d, DockState.DockRight);
            //new DockContent() { Text = "Свойства" }.Show(d, DockState.DockLeftAutoHide);
            this.d = new ObjectDiagram();
            deviceManager = new WinFormsDeviceManager(panel1.Handle);
            drawingManager = new DrawingManager(deviceManager, OnRender);
            drawingManager.Resize(new SharpDX.Size2(panel1.Width, panel1.Height));
            panel1.Resize += (c, ex) => { drawingManager.Resize(new SharpDX.Size2(panel1.Width, panel1.Height)); };
            panel1.Paint += panel1_Paint;
            panel1.MouseMove += panel1_MouseMove;
        }
        private void OnRender(DrawingContext dc)
        {
            dc.D2DTarget.Clear(SharpDX.Color.White) ;
            dc.D2DTarget.DrawRectangle(new SharpDX.RectangleF(p.X, p.X, 25, 25), dc.StrokeBrush);
            dc.D2DTarget.DrawLine(new SharpDX.Vector2(0, panel1.Height), new SharpDX.Vector2(panel1.Width,0),
                dc.StrokeBrush); 
        }
        private void Form2_ResizeEnd(object sender, EventArgs e)
        {
 
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                ;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        private void Form2_Resize(object sender, EventArgs e)
        {
            //panel1.Size = new Size(this.Width - 50, this.Height - 50);
           
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            panel1.Size = new Size(panel1.Size.Width * 2, panel1.Size.Height * 2);
        }

        private void panel1_Move(object sender, EventArgs e)
        {
          
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
            panel1.Invalidate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX;
namespace Seal2D.Win
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void seal2DCanvas1_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            Seal.Figures.Line.FindDelegate = seal2DCanvas1.Diagram.Get;
            for(int i=0;i<30;i++)
            {
               var figure = new Seal.Figures.GeometryFigure(new Seal.Geometries.EllipseGeometry());
              //  var figure = new Seal.Figures.GeometryFigure();
                figure.Location = new Seal.Location(rng.Next(500), rng.Next(500));
                seal2DCanvas1.Diagram.Add(figure);
            }
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void seal2DCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
            {

            }
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            if(d.ShowDialog()==DialogResult.OK)
            {
                Seal.IO.JsonDiagramSerializer s = new Core.IO.JsonDiagramSerializer();
                s.Save(d.FileName, seal2DCanvas1.Diagram);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if(d.ShowDialog()==DialogResult.OK)
            {
                Seal.IO.JsonDiagramSerializer s = new Core.IO.JsonDiagramSerializer();
                seal2DCanvas1.Diagram = s.Load(d.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  var renderer = Antiufo.Controls.Windows7Renderer.Instance;
          //  toolStrip1.Renderer = renderer;
            //statusStrip1.Renderer = renderer;
        }

        private void seal2DCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            lblMousePosition.Text = String.Format("{0},{1}пкс", e.X, e.Y);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            var Width = this.ClientSize.Width;
            var Height = this.ClientSize.Height;
            var s = this.seal2DCanvas1;
            if (s.Width >= Width || s.Height >= Height)
                s.Location = new System.Drawing.Point(0, 0);
            else
                s.Location = new System.Drawing.Point(Width / 2 - s.Width / 2, Height / 2 - s.Height / 2);
        }
    }
}

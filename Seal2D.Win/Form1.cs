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
        Seal2D.Core.Figures.Figure g;
        public Form1()
        {
            InitializeComponent();
        }

        private void seal2DCanvas1_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            var q = new Seal2D.Core.Figures.GeometryFigure();
            q.Location = new SharpDX.Point(rng.Next(500), rng.Next(500));
            seal2DCanvas1.Diagram.Add(q);
            seal2DCanvas1.Invalidate();
            this.g = q;
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void seal2DCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                var animation = new Seal2D.Core.Animations.MoveAnimation(g, e.X, e.Y);
                animation.Execute();
            }
            
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
    }
}

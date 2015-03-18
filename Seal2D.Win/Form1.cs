using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var g = new Seal2D.Core.Figures.GroupFigure();
            for (int i = 0; i < 20;i++ )
            {
             
                var f = new Seal2D.Core.Figures.GeometryFigure();
                f.Location = new SharpDX.Point(rng.Next(1000), rng.Next(500));
                seal2DCanvas1.Diagram.Add(f);
                g.Add(f);
               
            }
           //  seal2DCanvas1.Diagram.Groups.Add(g);
            var q = new Seal2D.Core.Figures.GeometryFigure();
            q.Location = new SharpDX.Point(rng.Next(500), rng.Next(500));
            seal2DCanvas1.Diagram.Add(q);
                seal2DCanvas1.Invalidate();
        }
    }
}

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
            seal2DCanvas1.Diagram.Add(new Seal2D.Core.Figures.GeometryFigure());
            seal2DCanvas1.Invalidate();
        }
    }
}

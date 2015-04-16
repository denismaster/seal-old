using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seal.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var renderer = new Seal2DToolstripRenderer();
            toolStrip1.Renderer = renderer;
            statusStrip1.Renderer = renderer;
            menuStrip1.Renderer = renderer;
        }
    }
}

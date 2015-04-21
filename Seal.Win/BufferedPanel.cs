using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seal.Win
{
    public partial class BufferedPanel : Panel
    {
        public BufferedPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque |
                ControlStyles.ResizeRedraw | ControlStyles.Selectable
                | ControlStyles.UserPaint, true);
            InitializeComponent();
            
        }

        private void BufferedPanel_Load(object sender, EventArgs e)
        {

        }
    }
}

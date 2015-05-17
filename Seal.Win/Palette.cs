using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seal.Figures;
namespace Seal.Win
{
    public partial class Palette : Form
    {
        private MainForm MainForm;
        private bool isFill;
        public Palette(MainForm F1)
        {
            MainForm = F1;
            MainForm.Enabled = false;
            InitializeComponent();
            Color paintcolor = Color.FromArgb(0, 0, 0);
            Bitmap bmp = (Bitmap)Colors.Image.Clone();
            for (int i = 0; i <= 255; i++)
                for (int j = 0; j <= 255; j++)
                {
                    paintcolor = Color.FromArgb(i, j, 127);
                    bmp.SetPixel(i, j, paintcolor);

                }
            Colors.Image = bmp;
            bmp = (Bitmap)BlueShades.Image.Clone();
            for (int i = 255; i >= 0; i--)
                for (int j = 0; j < 10; j++)
                {
                    paintcolor = Color.FromArgb(0, 0, 255 - i);
                    bmp.SetPixel(j, i, paintcolor);
                }
            BlueShades.Image = bmp;
            Rvalue.Text = "0";
            Gvalue.Text = "0";
            Bvalue.Text = Blue.Value.ToString();
            SelectedColor.BackColor = Color.FromArgb(0, 0, 127);

        }

        

        private void Palette_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Enabled = true;
        }


        private void Colors_MouseClick(object sender, MouseEventArgs e)
        {
            Color paintcolor = Color.FromArgb(0, 0, 0);
            Bitmap bmp = (Bitmap)BlueShades.Image.Clone();
            Rvalue.Text = safe(e.X).ToString();
            Gvalue.Text = safe(e.Y).ToString();
            for (int i = 255; i >= 0; i--)
                for (int j = 0; j < 10; j++)
                {
                    paintcolor = Color.FromArgb(safe(e.X), safe(e.Y), 255 - i);
                    bmp.SetPixel(j, i, paintcolor);
                }
            BlueShades.Image = bmp;
        }

        private void Blue_Scroll(object sender, EventArgs e)
        {
            Bvalue.Text = Blue.Value.ToString();
        }

        private int safe(int col)
        {
            if (col > 255)
                return 255;
            else if (col < 0)
                return 0;
            else
                return col;
        }

        private void Rvalue_TextChanged(object sender, EventArgs e)
        {
            int r = 0, g = 0, b = 0;
            if (Rvalue.Text != "" && Gvalue.Text != "" && Bvalue.Text != "")
            {
                r = Convert.ToInt32(Rvalue.Text);
                g = Convert.ToInt32(Gvalue.Text);
                b = Convert.ToInt32(Bvalue.Text);
                SelectedColor.BackColor = Color.FromArgb(r, g, b);
            }
        }

        private void Colors_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Colors_MouseClick(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.getCanvas().Diagram.SelectedFigure == null)
            {
                Close();
                return;
            }
            float red = Convert.ToInt32(Rvalue.Text) / 256f;
            float green = Convert.ToInt32(Gvalue.Text) / 256f;
            float blue = Convert.ToInt32(Bvalue.Text) / 256f;
            if (MainForm.getCanvas().Diagram.SelectedFigure is IFillColorable)
                if (isFill)
                {
                    (MainForm.getCanvas().Diagram.SelectedFigure as IFillColorable).FillColor = 
                        new SharpDX.Color4(red, green, blue, 1f);
                    Close();
                    return;
                }
                else
                {
                    (MainForm.getCanvas().Diagram.SelectedFigure as IFillColorable).Color =
                        new SharpDX.Color4(red, green, blue, 1f);
                    Close();
                    return;
                }
            else if (MainForm.getCanvas().Diagram.SelectedFigure is IColorable)
                if (!isFill)
                {
                    (MainForm.getCanvas().Diagram.SelectedFigure as IColorable).Color =
                        new SharpDX.Color4(red, green, blue, 1f);
                }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Palette_Load(object sender, EventArgs e)
        {

        }
        public void setIsFill(bool fill)
        {
            isFill = fill;
        }
    }
}

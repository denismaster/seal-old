using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seal.Controllers;
using Seal.Figures;
namespace Seal.Win
{
    public partial class MainForm : Form
    {
        protected Figures.Figure CopiedFigure;
        private IControllerFactory ControllerFactory;
        protected Seal.Figures.Diagram Diagram
        {
            get
            {
                return seal2DCanvas1.Diagram;
            }
        }
        protected Controller Controller
        {
            get
            {
                return seal2DCanvas1.ModeController;
            }
            set
            {
                seal2DCanvas1.ModeController = value;
            }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }

        private void btnSelection_Click(object sender, EventArgs e)
        {
            seal2DCanvas1.ModeController = new Seal.Controllers.SelectionController(Diagram);
        }

        private void menuFigures_Click(object sender, EventArgs e)
        {
            seal2DCanvas1.ModeController = new
                Seal.Controllers.AddFigureController<Seal.Geometries.RectangleGeometry>(Diagram);
        }

        private void seal2DCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            //lblLocation.Text = String.Format("{0},{1}", e.X, e.Y);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToolStripManager.Renderer = new Seal.Win.SealToolStripRenderer();
            Seal.Figures.Line.FindDelegate = Diagram.Get;
            ControllerFactory = new ControllerFactory(Diagram);
            seal2DCanvas1.ModeController = new Seal.Controllers.SelectionController(Diagram);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            var group = Diagram.SelectedFigure as Seal.Figures.Group;
            if(group!=null)
            {
                Diagram.Groups.AddLast(group);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            var group = Diagram.SelectedFigure as Seal.Figures.Group;
            if (group != null)
            {
                Diagram.Groups.Remove(group);
            }
           // Diagram.Add(new GeometryFigure( new Seal.Figures.Interfaces.MyGeometry()));
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var figure = Diagram.SelectedFigure as Seal.Figures.IColorable;
            if(figure!=null)
            {
                ColorDialog dialog = new ColorDialog();
                if(dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                {
                    var color = dialog.Color;
                    figure.Color = new SharpDX.Color(color.R, color.G, color.B, color.A);
                }
            }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var figure = Diagram.SelectedFigure as Seal.Figures.IFillColorable;
            if (figure != null)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var color = dialog.Color;
                    figure.FillColor = new SharpDX.Color(color.R, color.G, color.B, color.A);
                }
            }
        }

        private void seal2DCanvas1_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            var ofd = new OpenFileDialog();
            ofd.Multiselect=true;
            if(ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                foreach(var filename in ofd.FileNames )
                {
                    var location = new Location(rng.Next(200), rng.Next(200));
                    var image = new Seal.Figures.ImageFigure
                        (new Seal.Images.BitmapImageProvider(this.seal2DCanvas1.RenderTarget).Get(filename));
                    image.Location = location;
                    Diagram.Add(image);
                }
            }
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            CutFigure();
        }

        private void CutFigure()
        {
            if (Diagram.SelectedFigure != null)
            {
                CopiedFigure = Diagram.SelectedFigure;
                Diagram.Delete(CopiedFigure);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyFigure();
        }

        private void CopyFigure()
        {
            if (Diagram.SelectedFigure != null)
            {
                CopiedFigure = Diagram.SelectedFigure;
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            PasteFigure();
        }

        private void PasteFigure()
        {
            if (CopiedFigure != null)
            {
                Diagram.Add(CopiedFigure);
            }
        }

        private void menuFigures_Click_1(object sender, EventArgs e)
        {
            Controller = ControllerFactory.Get<AddFigureController<Seal.Geometries.RectangleGeometry>>();
        }

        private void btnSelection_Click_1(object sender, EventArgs e)
        {
            Controller = ControllerFactory.Get<SelectionController>();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Controller = ControllerFactory.Get<AddFigureController<Seal.Geometries.EllipseGeometry>>();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Controller = ControllerFactory.Get<AddLineController>();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            String s = "";
            if (ShowInputDialog(ref s) == DialogResult.OK)
            {
                var newPolygon = new Polygon(Convert.ToInt32(s), 100, 100);
                seal2DCanvas1.Diagram.Add(newPolygon);
                newPolygon.FillColor = new SharpDX.Color(255, 0, 255, 255);
            }
        }
        private DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "N углов";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            textBox.KeyPress += new KeyPressEventHandler(detectKeyPress);
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }


        public void detectKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        public Seal2D.Control.Seal2DCanvas getCanvas()
        {
            return this.seal2DCanvas1;
        }

        private void toolStripButton12_Click_1(object sender, EventArgs e)
        {
            Palette pal = new Palette(this);
            pal.setIsFill(true);
            pal.Show();

        }

        private void toolStripButton13_Click_1(object sender, EventArgs e)
        {
            Palette pal = new Palette(this);
            pal.setIsFill(false);
            pal.Show();
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            var ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var filename in ofd.FileNames)
                {
                    var location = new Location(rng.Next(200), rng.Next(200));
                    var image = new Seal.Figures.ImageFigure
                        (new Seal.Images.BitmapImageProvider(this.seal2DCanvas1.RenderTarget).Get(filename));
                    image.Location = location;
                    Diagram.Add(image);
                }
            }
        }
        private bool canAdd = true;
        private void seal2DCanvas1_Click_1(object sender, EventArgs e)
        {
            //var rng = new Random();
            //for (int i = 0; i < 1000; i++)
            //{
            //    var f = new Seal.Figures.GeometryFigure(new Seal.Geometries.RectangleGeometry());
            //    f.Location = new Location(rng.Next(800), rng.Next(480));
            //    Diagram.Add(f);
            //}
            //if (canAdd)
            //{
            //    var f = new Seal.Figures.GeometryFigure(new Seal.Geometries.RectangleGeometry());
            //    f.Location = new Location(100, 100);
            //    var f2 = new Seal.Figures.GeometryFigure(new Seal.Geometries.RectangleGeometry());
            //    f2.Location = new Location(300, 300);
            //    var rng = new Random();
            //    var points = new Location[4];
            //    for (int i = 0; i < points.Length; i++)
            //    {
            //        points[i] = new Location(rng.Next(400), rng.Next(400));
            //    }
            //    var line = new CurveLine(f, f2, points);
            //    Diagram.Add(f);
            //    Diagram.Add(f2);
            //    Diagram.Add(line);
            //    canAdd = false;
            //}
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Controller = ControllerFactory.Get<StrokeController>();
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            var figures = new List<Figure>();
            foreach(var f in Diagram.Figures)
            {
                if(f is StrokeFigure )
                {
                    figures.Add(f);
                }
            }
            foreach(var f in figures)
            {
                Diagram.Figures.Remove(f);
            }
            Invalidate();
        }

        private void seal2DCanvas1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Diagram.BringToFront(Diagram.SelectedFigure);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Diagram.SendToBack(Diagram.SelectedFigure);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            var f = Diagram.SelectedFigure as GeometryFigure;
            if(f!=null)
            {
                f.text.Value = toolStripTextBox1.Text;
            }
        }
    }
}

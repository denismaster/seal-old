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
    }
}

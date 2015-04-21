using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seal;
using Seal.Figures;
using Seal.Geometries;
using Seal.Drawing;
using SharpDX;
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
            seal2DCanvas1.Diagram = new ObjectDiagram();
            //seal2DCanvas1.MouseMove += (s, ex) => { lblLocation.Text = String.Format("{0},{1} пкс", ex.X, ex.Y); };
        }

        private void bufferedPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void canvas_DoubleClick(object sender, EventArgs e)
        {
            //Random rng = new Random();
            //Seal.Figures.SolidFigure2 figure = null;
            //Seal.Figures.Line.FindDelegate = seal2DCanvas1.Diagram.FindFigureByPoint;
            //for (int i = 0; i < 5; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        figure = new Seal.Figures.SolidFigure2(new Seal.Geometries.EllipseGeometry());
            //    }
            //    else
            //        figure = new Seal.Figures.SolidFigure2(new Seal.Geometries.RectangleGeometry());
            //    figure.Location = new Seal.Location(rng.Next(500), rng.Next(500));
            //    seal2DCanvas1.Diagram.Add(figure);
            //}
            //SharpDX.Vector2[] arr = new SharpDX.Vector2[5];
            //arr[0] = new Vector2(100, 200);
            //arr[1] = new Vector2(200, 100);
            //arr[2] = new Vector2(150, 100);
            //arr[3] = new Vector2(100, 150);
            //arr[4] = new Vector2(150, 150);
            //var l = new Seal.Figures.PolyLine(figure,
            //    new Seal.Figures.SolidFigure2(new Seal.Geometries.RectangleGeometry()),
            //    arr);

            //seal2DCanvas1.Diagram.Add(l.To as Seal.Figures.Figure);
            //seal2DCanvas1.Diagram.Add(l);
            seal2DCanvas1.Diagram.Add(new Polygon(5, 300, 300));
            seal2DCanvas1.Diagram.Add(new Polygon(3, 100, 100));
            seal2DCanvas1.Diagram.Add(new Polygon(10, 500,100));
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var group = seal2DCanvas1.Diagram.SelectedFigure as Group;
            if (group != null)
            {
                seal2DCanvas1.Diagram.Groups.AddLast(group);
            }
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            var group = seal2DCanvas1.Diagram.SelectedFigure as Group;
            if (group != null)
            {
                seal2DCanvas1.Diagram.Groups.Remove(group);
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            var figure = seal2DCanvas1.Diagram.SelectedFigure;
            seal2DCanvas1.Diagram.BringToFront(figure);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var figure = seal2DCanvas1.Diagram.SelectedFigure;
            seal2DCanvas1.Diagram.SendToBack(figure);
        }

        private void seal2DCanvas1_MouseMove(object sender, MouseEventArgs e)
        {

            lblLocation.Text = String.Format("{0},{1} пкс", e.X, e.Y);
        }

        private void seal2DCanvas1_Resize(object sender, EventArgs e)
        {
            lblSize.Text = String.Format("{0}x{1}пкс", seal2DCanvas1.Width, seal2DCanvas1.Height);
        }
    }
}

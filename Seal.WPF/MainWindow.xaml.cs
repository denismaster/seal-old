using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Seal.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Seal.Figures.Diagram d;
        private int _mouseX;
        private int _mouseY;
        public int mouseX
        {
            get
            {
                return _mouseX;
            }
            set
            {
                _mouseX = value;
                NotifyPropertyChanged();
            }
        }
        public int mouseY
        {
            get
            {
                return _mouseY;
            }
            set
            {
                _mouseY = value;
                NotifyPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Seal2D.Control.Seal2DCanvas d = this.Host.Child as Seal2D.Control.Seal2DCanvas;
            this.d = d.Diagram;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void Seal2DCanvas_DoubleClick(object sender, EventArgs e)
        {
            
            Random rng = new Random();
            Seal.Figures.Line.FindDelegate = d.Get;
            for (int i = 0; i < 30; i++)
            {
                Seal.Figures.SolidFigure2 figure;
                if (i % 2 == 0)
                {
                    figure = new Seal.Figures.SolidFigure2(new Seal.Geometries.EllipseGeometry());
                }
                else
                    figure = new Seal.Figures.SolidFigure2(new Seal.Geometries.RectangleGeometry());
                figure.Location = new Seal.Location(rng.Next(500), rng.Next(500));
                d.Add(figure);
            }
        }

        private void Seal2DCanvas_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.mouseX = e.X;
            this.mouseY = e.Y;
            NotifyPropertyChanged();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var g = d.SelectedFigure as Seal.Figures.GroupFigure;
            if(g!=null)
            {
                d.Groups.AddLast(g);
            }
        }
    }
}

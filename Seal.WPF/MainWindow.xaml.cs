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
            var seal2DCanvas1 = this.Host.Child as Seal2D.Control.Seal2DCanvas;
            Random rng = new Random();
            Seal2D.Core.Figures.Line.FindDelegate = seal2DCanvas1.Diagram.FindFigureByPoint;
            var q = new Seal2D.Core.Figures.GeometryFigure();
            q.Location = new Seal2D.Core.Location(rng.Next(500), rng.Next(500));
            seal2DCanvas1.Diagram.Add(q);

            var a = new Seal2D.Core.Figures.GeometryFigure();
            a.Location = new Seal2D.Core.Location(rng.Next(500), rng.Next(500));
            seal2DCanvas1.Diagram.Add(a);

            var line = new Seal2D.Core.Figures.ArrowedLine(q,a);
            seal2DCanvas1.Diagram.Add(line);
            seal2DCanvas1.Diagram.SelectedFigure = q;
        }

        private void Seal2DCanvas_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.mouseX = e.X;
            this.mouseY = e.Y;
            NotifyPropertyChanged();
        }
    }
}

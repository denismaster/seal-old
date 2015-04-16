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
using Seal2D.Core;
using Seal2D.Core.Figures;
using Seal2D.Core.Drawing;
using SharpDX.Direct2D1;
namespace Seal2D.Wpf.Test1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDeviceManager deviceManager;
        private IDrawingManager drawingManager;
        private Diagram d;
        
        System.Timers.Timer t1;
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            ;
            d = new ObjectDiagram();
            host.Width = 100;
            host.Height = 100;
            deviceManager = new WinFormsDeviceManager(this.host.Handle);
            drawingManager = new DrawingManager(deviceManager, OnRender);
            drawingManager.Resize(new SharpDX.Size2(DoubleToInt(host.Width),DoubleToInt(host.Height)));
            t1 = new System.Timers.Timer();
            t1.Interval = 100;
            t1.Elapsed += (c,q) => { i += 1; };
            host.SizeChanged += (c, ex) => { drawingManager.Resize(new SharpDX.Size2(DoubleToInt(host.Width), DoubleToInt(host.Height))); };
            t1.Start();
        }
        private int DoubleToInt(double d)
        {
            return Convert.ToInt32(Math.Round(d));
        }
        private void OnRender(Seal2D.Core.Drawing.DrawingContext dc)
        {
            dc.D2DTarget.Clear(SharpDX.Color.White);
            dc.D2DTarget.DrawRectangle(new SharpDX.RectangleF(i, i, 25, 25), dc.StrokeBrush);
        }
        private void Panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            drawingManager.StartRendering();
        }

        private void host_MouseMove(object sender, MouseEventArgs e)
        {
            drawingManager.StartRendering();
        }
    }
}

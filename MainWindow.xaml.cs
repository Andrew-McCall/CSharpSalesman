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

namespace Salesman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SolidColorBrush MarkerFillBrush;
        private readonly double MARKER_RADIUS = 10;

        public MainWindow()
        {
            InitializeComponent();
            MarkerFillBrush = new SolidColorBrush();
            MarkerFillBrush.Color = Colors.Black;
        }

        protected void Canvas_Click(object sender, MouseEventArgs e)
        {
            Point clickCoords = e.GetPosition((IInputElement)sender);

            Canvas canvas = (Canvas) sender;

            Ellipse marker = new Ellipse { Width = MARKER_RADIUS, Height = MARKER_RADIUS, Fill = MarkerFillBrush };

            double offset = MARKER_RADIUS / 2;
            Thickness margin = new Thickness(clickCoords.X - offset, clickCoords.Y - offset, 0, 0);
            marker.Margin = margin;

            canvas.Children.Add(marker);

        }

    }
}

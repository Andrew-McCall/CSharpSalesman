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
    public partial class MainWindow : Window
    {
        private readonly SolidColorBrush MarkerFillBrush = new SolidColorBrush();
        private readonly double MARKER_DIAMETER = 10;
        private readonly double MARKER_RADIUS;

        private readonly Salesman logic = new Salesman();
        private readonly Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            MarkerFillBrush.Color = Colors.Black;
            this.MARKER_RADIUS = MARKER_DIAMETER / 2;
        }

        protected void Canvas_Click(object sender, MouseEventArgs e)
        {
            Point clickCoords = e.GetPosition(this.Markers);

            Ellipse marker = new Ellipse { Width = MARKER_DIAMETER, Height = MARKER_DIAMETER, Fill = MarkerFillBrush };

            double x = clickCoords.X - MARKER_RADIUS;
            double y = clickCoords.Y - MARKER_RADIUS;

            Thickness margin = new Thickness(x, y, 0, 0);
            marker.Margin = margin;

            _ = this.Markers.Children.Add(marker);
            logic.AddPoint(new DataPoint(x, y));
        }

        private Point RandomCoords()
        {
            return new Point(rnd.Next(73500) / 100 + 15, rnd.Next(33000) / 100 + 15);
        }

        private void Randomise_Button_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < logic.Length; i++)
            {
                DataPoint point = logic.GetPoint(i);
                Point coords = RandomCoords();
                point.X = coords.X;
                point.Y = coords.Y;

                Shape marker = (Shape)this.Markers.Children[i];
                marker.Margin = new Thickness(point.X, point.Y, 0, 0);

                Lines.Children.Clear();
            }
        }



        private void Add_Point_Button_Click(object sender, RoutedEventArgs e)
        {
            Ellipse marker = new Ellipse { Width = MARKER_DIAMETER, Height = MARKER_DIAMETER, Fill = MarkerFillBrush };

            Point coords = RandomCoords();

            Thickness margin = new Thickness(coords.X, coords.Y, 0, 0);
            marker.Margin = margin;

            _ = this.Markers.Children.Add(marker);
            logic.AddPoint(new DataPoint(coords.X, coords.Y));
        }
        private void Calculate_Button_Click(object sender, RoutedEventArgs e)
        {
            if (logic.Length > 0)
            {
                logic.Calculate();
                Lines.Children.Clear();
                RenderLine(logic.GetPoint(0));
            }
        }

        private void RenderLine(DataPoint prev)
        {
            if (Lines.Children.Count == logic.Length || prev.Next == -1) return;

            Line newLine = new Line();
            newLine.Stroke = MarkerFillBrush;
            newLine.StrokeThickness = 3;


            newLine.X1 = prev.X + MARKER_RADIUS;
            newLine.Y1 = prev.Y + MARKER_RADIUS;
            DataPoint current = logic.GetPoint(prev.Next);
            newLine.X2 = current.X + MARKER_RADIUS;
            newLine.Y2 = current.Y + MARKER_RADIUS;

            _ = Lines.Children.Add(newLine);
            RenderLine(current);
        }

    }
}

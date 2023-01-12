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
using Salesman.Algorithms;

namespace Salesman
{
    public partial class MainWindow : Window
    {
        private readonly SolidColorBrush MarkerFillBrush = new SolidColorBrush();
        private readonly SolidColorBrush LineFillBrush = new SolidColorBrush();
        private readonly double MARKER_DIAMETER = 10;
        private readonly double MARKER_RADIUS;

        private readonly Salesman Logic = new Salesman();
        private readonly Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            MarkerFillBrush.Color = Colors.Black;
            LineFillBrush.Color = Colors.LightBlue;

            this.MARKER_RADIUS = MARKER_DIAMETER / 2;

            //Logic.Algorithm = new GreedyAll();
            Logic.Algorithm = new BruteForce();
        }

        protected void Marker_Click(object sender, MouseEventArgs e)
        {
            Point clickCoords = new Point(e.GetPosition(this.Markers));

            Ellipse marker = new Ellipse { Width = MARKER_DIAMETER, Height = MARKER_DIAMETER, Fill = MarkerFillBrush };

            double x = clickCoords.X - MARKER_RADIUS;
            double y = clickCoords.Y - MARKER_RADIUS;

            Thickness margin = new Thickness(x, y, 0, 0);
            marker.Margin = margin;

            _ = this.Markers.Children.Add(marker);
            Logic.Points.AddPoint(new Point(x, y));
        }

        private Point RandomCoords()
        {
            return new Point(rnd.Next(73500) / 100 + 15, rnd.Next(33000) / 100 + 15);
        }

        private void Randomise_Button_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < Logic.Points.Length; i++)
            {
                Point point = Logic.Points.GetPoint(i);
                Point coords = RandomCoords();
                point.X = coords.X;
                point.Y = coords.Y;

                Shape marker = (Shape)this.Markers.Children[i];
                marker.Margin = new Thickness(point.X, point.Y, 0, 0);

                Lines.Children.Clear();
            }
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Markers.Children.Clear();
            this.Lines.Children.Clear();

            this.Logic.Points.Clear();
        }

        private void Add_Point_Button_Click(object sender, RoutedEventArgs e)
        {
            Ellipse marker = new Ellipse { Width = MARKER_DIAMETER, Height = MARKER_DIAMETER, Fill = MarkerFillBrush };

            Point coords = RandomCoords();

            Thickness margin = new Thickness(coords.X, coords.Y, 0, 0);
            marker.Margin = margin;

            _ = this.Markers.Children.Add(marker);
            Logic.Points.AddPoint(new Point(coords.X, coords.Y));
        }

        private void Calculate_Button_Click(object sender, RoutedEventArgs e)
        {
            Button calculateButton = (Button)sender;
            calculateButton.IsEnabled = false;
            if (Logic.Points.Length > 0)
            {
                Logic.RunAlgorithm();
                Lines.Children.Clear();
                RenderLine(0);
                MessageBox.Show(Math.Round(SolutionMaths.DistanceTotal(Logic.Points.GetAllPoints(), Logic.Solution, false), 1).ToString(), Title = "Distance Squared");
            }
            calculateButton.IsEnabled = true;
        }

        private void RenderLine(int prev)
        {
            if (Lines.Children.Count == Logic.Points.Length || Logic.Solution[prev] == -1) return;
            Point prevPoint = Logic.Points.GetPoint(prev);

            int current = Logic.Solution[prev];
            Point currentPoint = Logic.Points.GetPoint(current);

            Line newLine = new Line();
            newLine.Stroke = LineFillBrush;
            newLine.StrokeThickness = 3;


            newLine.X1 = prevPoint.X + MARKER_RADIUS;
            newLine.Y1 = prevPoint.Y + MARKER_RADIUS;
            newLine.X2 = currentPoint.X + MARKER_RADIUS;
            newLine.Y2 = currentPoint.Y + MARKER_RADIUS;

            _ = Lines.Children.Add(newLine);
            RenderLine(current);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;

namespace Salesman
{
    class DataPoint
    {

        public double X { set; get; }
        public double Y { set; get; }
        public int Next { set; get; } = -1;
        public Shape Marker { set; get; }
        public Line Line { set; get; }

        public DataPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public DataPoint(double x, double y, Shape marker)
        {
            this.X = x;
            this.Y = y;
            this.Marker = marker;
        }

        public bool EqualCoords(DataPoint point)
        {
            return this.X == point.X && this.Y == point.Y;
        }

        public void MovePoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
            UpdateShape();
        }

        public void UpdateShape()
        {
            Thickness margin = new Thickness(this.X, this.Y, 0, 0);
            this.Marker.Margin = margin;
        }

    }
}

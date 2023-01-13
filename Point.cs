using System;

namespace Salesman
{
    class Point
    {

        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(System.Windows.Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

    }
}

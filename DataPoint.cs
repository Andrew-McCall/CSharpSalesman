using System;
using System.Collections.Generic;
using System.Text;

namespace Salesman
{
    class DataPoint
    {

        public double X { set; get; }
        public double Y { set; get; }
        public int Next { set; get; } = -1;

        public DataPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public DataPoint(double x, double y, int next)
        {
            this.X = x;
            this.Y = y;
            this.Next = next;
        }

        public bool EqualCoords(DataPoint point)
        {
            return this.X == point.X && this.Y == point.Y;
        }

    }
}

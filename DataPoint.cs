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
        
        public DataPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool EqualCoords(DataPoint point)
        {
            return this.X == point.X && this.Y == point.Y;
        }


    }
}

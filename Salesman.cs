using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace Salesman
{
    class Salesman
    {
        private DataPoint[] Points = new DataPoint[0];
        public int Length { get; private set; } = 0;
       
        public void AddPoint(DataPoint point)
        {
            
            DataPoint[] data = Points;
            Points = new DataPoint[Length + 1];
            for (int i = 0; i < Length; i++)
            {
                Points[i] = data[i];
            }
            Points[Length] = point;
            Length++;
        }

        public int IndexOf(DataPoint point)
        {
            for (int i = 0; i < Length; i++)
            {
                if (Points[i].EqualCoords(point)){
                    return i;
                }
            }
            return -1;
        }

        public DataPoint GetPoint(int index)
        {
            return Points[index];
        }

        public void Calculate()
        {
            
            for (int i = 0; i < Length - 1; i++)
            {
                Points[i].Next = i + 1;
            }
            Points[Length - 1].Next = 0;

            /*
            for (int i = 0; i < Length - 1; i++)
            {
                Points[i].Next = i;

                Line line = new Line();
                line.X1 = Points[i].X;
                line.Y1 = Points[i].Y;
                line.X2 = Points[i + 1].X;
                line.Y2 = Points[i + 1].Y;

                Points[i].Line = line;
            }
            Points[Length-1].Next = 0;
            Line finalLine = new Line();
            finalLine.X1 = Points[Length-1].X;
            finalLine.Y1 = Points[Length-1].Y;
            finalLine.X2 = Points[0].X;
            finalLine.Y2 = Points[0].Y;
            Points[Length - 1].Line = finalLine;
            */
        }

        public bool isCongruent()
        {
            return false;
        }

        public void Solve()
        {

        }

    }
}

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
       
        public void Clear()
        {
            this.Points = new DataPoint[0];
            this.Length = 0;
        }

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
            if (Length > 1)
            {
                for (int i = 0; i < Length - 1; i++)
                {
                    Points[i].Next = i + 1;
                }
                Points[Length - 1].Next = 0;
            }
            
        }

        public double Distance()
        {
            if (Length <= 1) return -1;

            int count = 0;
            double distance = 0;

            int current = Points[0].Next;
            if (Points[current].Next == -1) return -1;

            while (current != 0)
            {
                if (count > Length) return -1;

                int next = Points[current].Next;

                if (next == -1) return -1;
                distance += DistanceBetween(this.Points[current], this.Points[next]);

                count++;
                current = next;
            }

            return distance;
        }

        private double DistanceBetween(DataPoint pointA, DataPoint pointB)
        {
            return Math.Abs(pointA.X - pointB.X) + Math.Abs(pointA.Y - pointB.Y);
        }

        public void Solve()
        {

        }

    }
}

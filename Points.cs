using System;

namespace Salesman
{
    class Points
    {
       
        private Point[] Array = new Point[0]; 
        public int Length { get; private set; } = 0;

        public void Clear()
        {
            this.Array = new Point[0];
            this.Length = 0;
        }

        public void AddPoint(Point point)
        {
            Point[] data = Array;
            Array = new Point[Length + 1];
            for (int i = 0; i < Length; i++)
            {
                Array[i] = data[i];
            }
            Array[Length] = point;
            Length++;
        }

        public Point GetPoint(int index)
        {
            return Array[index];
        }

        public Point[] GetAllPoints()
        {
            return Array;
        }

    }
}

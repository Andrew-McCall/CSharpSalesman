using System;
using System.Collections.Generic;
using System.Text;

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

        public DataPoint Get(int index)
        {
            return Points[index];
        }

        public void Calculate()
        {

        }

        public void Solve()
        {

        }

    }
}

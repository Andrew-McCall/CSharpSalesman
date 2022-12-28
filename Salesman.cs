﻿using System;
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

        public bool IsCongruent()
        {
            if (Length <= 1) return false;

            int count = 0;

            int current = Points[1].Next;
            while (current != 0)
            {
                if (current == -1 || count > Length) return false;

                count++;
                current = Points[current].Next;
            }

            return true;
        }

        public double DistanceSquaredTotal()
        {
            if (!IsCongruent()) return -1;

            double distance = 0;
            int count = 0;

            DataPoint prev = Points[0];

            while (count <= Length)
            {
                count++;

                DataPoint next = Points[prev.Next];

                distance += DistanceBetweenSquared(prev, next);

                prev = next;

            }

            return distance;
        }

        private double DistanceBetweenSquared(DataPoint pointA, DataPoint pointB)
        {
            return Math.Pow(Math.Abs(pointA.X - pointB.X),2) + Math.Pow(Math.Abs(pointA.Y - pointB.Y), 2);
        }

        public double DistanceBetween(DataPoint pointA, DataPoint pointB)
        {
            return Math.Sqrt(DistanceBetweenSquared(pointA, pointB));
        }

        public void Solve()
        {

        }

    }
}

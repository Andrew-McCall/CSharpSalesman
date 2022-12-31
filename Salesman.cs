using System;
using System.Collections.Generic;
using System.Text;

namespace Salesman
{
    class Salesman
    {

        public IAlgorithm Algorithm;
        public int[] Solution;
        public Points Points;

        public Salesman()
        {
            this.Points = new Points();
        }

        public Salesman(Points points)
        {
            this.Points = points;
        }

        public void ChangeAlgorithm(IAlgorithm algorithm)
        {
            this.Algorithm = algorithm;
            this.Solution = Algorithm.Calculate(Points.GetAllPoints(), NullPath());
        }
        
        public bool IsCongruent()
        {
            if (Points.Length <= 1) return false;

            int count = 1;

            int current = Solution[0];
            while (current != 0)
            {
                if (current == -1 || count > Points.Length) return false;

                count++;
                current = Solution[current];
            }
            return count == Points.Length;
        }

        public int[] NullPath()
        {
            int[] solution = new int[Points.Length];
            for (int i = 0; i < solution.Length; i++)
            {
                solution[i] = -1;
            }
            return solution;
        }

        public void ClearPath()
        {
            this.Solution = NullPath();
        }

        /*
        public double DistanceTotal(bool isSquared = true)
        {
            if (!IsCongruent()) return -1;

            double distance = 0;
            int count = 0;

            DataPoint prev = Points[0];

            while (count <= Length)
            {
                count++;

                DataPoint next = Points[prev.Next];
                if (isSquared)
                {
                    distance += DistanceBetweenSquared(prev, next);
                }
                else
                {
                    distance += DistanceBetween(prev, next);
                }

                prev = next;

            }

            return distance;
        }
        */

        public static double DistanceBetweenSquared(Point pointA, Point pointB)
        {
            return Math.Pow(Math.Abs(pointA.X - pointB.X), 2) + Math.Pow(Math.Abs(pointA.Y - pointB.Y), 2);
        }

        public static double DistanceBetween(Point pointA, Point pointB)
        {
            return Math.Sqrt(DistanceBetweenSquared(pointA, pointB));
        }

    }
}

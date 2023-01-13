using System;
using System.Collections.Generic;
using System.Text;

namespace Salesman
{
    class SolutionMaths
    {
        public static double DistanceBetweenSquared(Point pointA, Point pointB)
        {
            return Math.Pow(Math.Abs(pointA.X - pointB.X), 2) + Math.Pow(Math.Abs(pointA.Y - pointB.Y), 2);
        }

        public static double DistanceBetween(Point pointA, Point pointB)
        {
            return Math.Sqrt(DistanceBetweenSquared(pointA, pointB));
        }

        public static double DistanceTotal(Point[] points, int[] solution, bool isSquared = true)
        {
            if (!IsCongruent(points, solution)) return -1;

            double distance = 0;
            int count = 0;

            int prev = 0;

            while (count <= points.Length)
            {
                count++;

                int next = solution[prev];
                if (isSquared)
                {
                    distance += DistanceBetweenSquared(points[prev], points[next]);
                }
                else
                {
                    distance += DistanceBetween(points[prev], points[next]);
                }

                prev = next;

            }

            return distance;
        }

        public static bool IsCongruent(Point[] points, int[] solution)
        {
            if (points.Length <= 1) return false;

            int count = 1;

            int current = solution[0];
            while (current != 0)
            {
                if (current == -1 || count > points.Length || current == solution[current]) return false;

                count++;
                current = solution[current];
            }
            return count == points.Length;
        }

        public static int[] NullPath(int pathLength)
        {
            int[] solution = new int[pathLength];
            for (int i = 0; i < solution.Length; i++)
            {
                solution[i] = -1;
            }
            return solution;
        }
    }
}

using System;

namespace Salesman.Algorithms
{
    class GreedyBase
    {

        public static int[] Calculate(Point[] points, int startingNode)
        {
            int[] solution = SolutionMaths.NullPath(points.Length);

            int count = 1;
            int current = startingNode;
            while (count < points.Length)
            {
                count++;
                int nearest = FindNearestEmptyPoint(current, points, solution);
                if (nearest == -1) throw new ArithmeticException("Path couldn't be calculated");
                solution[current] = nearest;
                current = nearest;
            }
            solution[current] = startingNode;

            return solution;

        }

        private static int FindNearestEmptyPoint(int nodeIndex, Point[] points, int[] solution)
        {
            Point currentPoint = points[nodeIndex];
            int nearest = -1;
            double lowestDistance = -1;
            for (int i = 0; i < points.Length; i++)
            {
                if (i == nodeIndex) continue;

                Point comparePoint = points[i];

                if (solution[i] != -1) continue;

                double distance = SolutionMaths.DistanceBetweenSquared(comparePoint, currentPoint);
                if (nearest == -1 || lowestDistance > distance)
                {
                    lowestDistance = distance;
                    nearest = i;
                }

            }
            return nearest;
        }
    }
}

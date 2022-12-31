using System;
using System.Collections.Generic;
using System.Text;

namespace Salesman.Algorithms
{
    class GreedyAll : IAlgorithm
    {
        public int[] Calculate(Point[] points, int[] solution)
        {
            int[] lowestSolution = GreedyBase.Calculate(points, 0);
            double distance = SolutionMaths.DistanceTotal(points, lowestSolution);

            for (int i = 1; i < points.Length; i++)
            {
                int[] currentSolution = GreedyBase.Calculate(points, i);
                double currentDistance = SolutionMaths.DistanceTotal(points, currentSolution);
                if (currentDistance < distance)
                {
                    distance = currentDistance;
                    lowestSolution = currentSolution;
                }
            }

            return lowestSolution;
        }

    }
}

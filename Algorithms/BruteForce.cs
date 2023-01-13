using System;

namespace Salesman.Algorithms
{
    class BruteForce : IAlgorithm
    {
        public int[] Calculate(Point[] points, int[] solution)
        {
            Heaps heaps = new Heaps(points.Length);

            double lowestDistance = -1;

            foreach( int[] pSolution in heaps.Combinations)
            {

                double pDistance = SolutionMaths.DistanceTotal(points, pSolution, true); // IsCongrunet subcall checks for vaild
                if (pDistance == -1) continue;
                if (lowestDistance == -1 || pDistance < lowestDistance)
                {
                    lowestDistance = pDistance;
                    solution = pSolution;
                }

            }

            return solution;
        }

    }
}

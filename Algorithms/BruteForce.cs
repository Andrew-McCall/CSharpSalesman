using System;
using System.Collections.Generic;
using System.Text;

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

                /*
                bool isVaild = true;
                for (int i = 0; i<pSolution.Length; i++)
                {
                    if (pSolution[i] == i)
                    {
                        isVaild = false;
                        break;
                    }
                }*/

                double pDistance = SolutionMaths.DistanceTotal(points, pSolution, false); // IsCongrunet subcall checks for vaild
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

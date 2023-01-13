using System;
using System.Collections.Generic;
using System.Text;

namespace Salesman.Algorithms
{
    class SingleLowestSwap : IAlgorithm
    {
        public void ChainSolution(int[] solution)
        {

            for (int i = 0; i < solution.Length; i++)
            {
                solution[i] = i + 1;
            }
            solution[^1] = 0;
        }

        public int[] Calculate(Point[] points, int[] solution)
        {
            ChainSolution(solution);

            bool isBetter = true;
            while (isBetter)
            {
                isBetter = false;

                for (int x = 0; x < points.Length; x++)
                {
                    int swap = FindLowestSwap(x, points, solution);
                    if (solution[x] != swap)
                    {
                        isBetter = true;
                        int nextStore = solution[x];
                        solution[x] = solution[swap];
                        solution[swap] = nextStore;
                    }
                }
            }
            return solution;
        }

        private int FindLowestSwap(int startingNode, Point[] points, int[] solution)
        {
            //Point nodePoint = points[node];

            int nodePoint = startingNode;

            int lowestIndex = solution[nodePoint];
            double lowestDistance = SolutionMaths.DistanceTotal(points, solution);
            for (int i = 0; i < points.Length; i++)
            {
                if (solution[nodePoint] != i)
                {
                    int iOldNext = solution[i];
                    solution[i] = solution[nodePoint];
                    solution[nodePoint] = iOldNext;

                    double currentDistance = SolutionMaths.DistanceTotal(points, solution);

                    if (lowestDistance > currentDistance && currentDistance != -1)
                    {
                        lowestDistance = currentDistance;
                        lowestIndex = i;
                    }

                    solution[nodePoint] = solution[i];
                    solution[i] = iOldNext;
                }
            }
            return lowestIndex;
        }

    }
}

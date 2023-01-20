using System;

namespace Salesman.Algorithms
{
    class GreedyZero : IAlgorithm
    {

        public int[] Calculate(Point[] points)
        {
            return GreedyBase.Calculate(points, 0);
        }

    }
}

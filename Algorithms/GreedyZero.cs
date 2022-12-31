using System;
using System.Collections.Generic;
using System.Text;

namespace Salesman.Algorithms
{
    class GreedyZero : IAlgorithm
    {

        public int[] Calculate(Point[] points, int[] solution)
        {
            return GreedyBase.Calculate(points, 0);
        }

    }
}

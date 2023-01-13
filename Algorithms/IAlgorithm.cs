using System;

namespace Salesman
{

    interface IAlgorithm
    {

        public int[] Calculate(Point[] points, int[] solution);

    }

}

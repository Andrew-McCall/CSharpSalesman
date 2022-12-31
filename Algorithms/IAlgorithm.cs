using System;
using System.Collections.Generic;
using System.Text;

namespace Salesman
{

    interface IAlgorithm
    {

        public int[] Calculate(Point[] points, int[] solution);

    }

}

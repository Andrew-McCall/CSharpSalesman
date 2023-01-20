using System;
using System.Collections.Generic;
using System.Text;

namespace Salesman.Algorithms
{
    class MenuedAlgorithm : IAlgorithm
    {

        public string DisplayName { set; get; }
        public IAlgorithm Algorithm { set; get; }

        public MenuedAlgorithm(string displayName, IAlgorithm algorithm)
        {
            this.DisplayName = displayName;
            this.Algorithm = algorithm;
        }
        
        public MenuedAlgorithm() { }

        public int[] Calculate(Point[] points)
        {
            return this.Algorithm.Calculate(points);
        }
    }
}

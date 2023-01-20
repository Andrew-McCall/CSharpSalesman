using System;

namespace Salesman
{
    class Salesman
    {

        public IAlgorithm Algorithm;
        public int[] Solution;
        public Points Points;

        public Salesman()
        {
            this.Points = new Points();
        }

        public Salesman(Points points)
        {
            this.Points = points;
        }

        public void RunAlgorithm()
        {
            this.Solution = Algorithm.Calculate(Points.GetAllPoints());
        }

        
        /*
        public void ClearPath()
        {
            this.Solution = SolutionMaths.NullPath(Points.Length) ;
        }

        public double DistanceTotal(bool isSquared = true)
        {
            return SolutionMaths.DistanceTotal(Points.GetAllPoints(), Solution, isSquared);
        }
        */

    }
}

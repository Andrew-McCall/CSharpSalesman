using System;
using System.Threading.Tasks;

namespace Salesman.Algorithms
{
    class BruteForceThreaded : IAlgorithm
    {

        public int[] Calculate(Point[] points)
        {
            Heaps heaps = new Heaps(points.Length);

            double[] distances = new double[heaps.Combinations.Count];
            Task[] tasks = new Task[heaps.Combinations.Count];
            TaskFactory factory = new TaskFactory();

            for (int i = 0; i < heaps.Combinations.Count; i++) {
                int j = i;
                tasks[i] = Task.Run(() =>
                {
                    int[] pSolution = (int[])heaps.Combinations[j];
                    double pDistance = SolutionMaths.DistanceTotal(points, pSolution, true); // IsCongrunet subcall checks for vaild
                    distances[j] = pDistance;
                });
            }

            Task.WaitAll(tasks);

            int lowest = 0;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[lowest] == -1 || (distances[i] != -1 && distances[lowest] > distances[i]))
                {
                    lowest = i;
                }
            }

            return (int[])heaps.Combinations[lowest];
        }
    }
}

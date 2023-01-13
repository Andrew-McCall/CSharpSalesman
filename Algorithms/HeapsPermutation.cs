using System;
using System.Collections.Generic;

namespace Salesman.Algorithms
{
    public class Heaps
    {

        public List<IList<int>> Combinations;

        public Heaps(int size)
        {
            Combinations = new List<IList<int>>();
            int[] inital = new int[size];
            for (int i = 0; i < size; i++)
            {
                inital[i] = i;
            }
            Permute(size, (int[])inital.Clone());

        }

        private void Permute(int currentLast, int[] array)
        {
            if (currentLast == 1) {
                Combinations.Add((int[])array.Clone());
            }
            else
            {
                Permute(currentLast - 1, array);
                for (int i = 0; i < currentLast - 1; i++)
                {
                    if (currentLast % 2 == 0)
                    {
                        Swap(ref array[i], ref array[currentLast - 1]);
                    }
                    else
                    {
                        Swap(ref array[0], ref array[currentLast - 1]);
                    }
                    Permute(currentLast - 1, array);
                }
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int aSaved = a;
            a = b;
            b = aSaved;
        }
    }
}
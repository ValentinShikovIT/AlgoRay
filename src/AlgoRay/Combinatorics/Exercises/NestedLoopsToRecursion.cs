using AlgoRay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics.Exercises
{
    public class NestedLoopsToRecursion
    {
        private int n;
        private int[] result;
        private readonly IList<int[]> loops = new List<int[]>();

        public AlgorithmicResult<IList<int[]>> Run(int input)
        {
            try
            {
                return Logic(input);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<IList<int[]>>(default, ex.Message);
            }
        }

        public AlgorithmicResult<IList<int[]>> Logic(int input)
        {
            n = input;

            result = new int[n];

            CreateLoops(0);

            return new AlgorithmicResult<IList<int[]>>(loops);
        }

        private void CreateLoops(int index)
        {
            if (index >= result.Length)
            {
                loops.Add(result.ToArray());
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                result[index] = i;
                CreateLoops(index + 1);
            }
        }
    }
}

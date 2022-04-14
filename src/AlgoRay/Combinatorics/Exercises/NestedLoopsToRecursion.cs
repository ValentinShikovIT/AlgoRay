using AlgoRay.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics.Exercises
{
    public class NestedLoopsToRecursion
    {
        private static int n;
        private static int[] result;
        private static readonly IList<int[]> loops = new List<int[]>();

        public static AlgorithmicResponse<IList<int[]>> Run(int input)
        {
            n = input;

            result = new int[n];

            CreateLoops(0);

            return new AlgorithmicResponse<IList<int[]>>(loops, true);
        }

        private static void CreateLoops(int index)
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

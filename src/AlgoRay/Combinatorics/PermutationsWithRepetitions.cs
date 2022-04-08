using AlgoRay.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics
{
    public class PermutationsWithRepetitions<T>
    {
        private static T[] permutation;
        private static bool[] used;
        private static readonly List<T[]> allPermutations = new List<T[]>();

        public static AlgorithmicResponse<T[]> Run(T[] input)
        {
            permutation = new T[input.Length];
            used = new bool[input.Length];

            Permutations(0, input);

            return new AlgorithmicResponse<T[]>(allPermutations, true);
        }

        private static void Permutations(int index, T[] input)
        {
            if (index >= permutation.Length)
            {
                allPermutations.Add(permutation.ToArray());
                return;
            }

            var duplicates = new HashSet<T>();

            for (int i = 0; i < input.Length; i++)
            {
                if (used[i] == false && !duplicates.Contains(input[i]))
                {
                    used[i] = true;
                    permutation[index] = input[i];
                    Permutations(index + 1, input);
                    used[i] = false;

                    duplicates.Add(input[i]);
                }
            }
        }
    }
}

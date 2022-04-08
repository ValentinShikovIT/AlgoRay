using AlgoRay.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics
{
    public class CombinationsWithRepetitions<T>
    {
        private static T[] combinations;
        private static IList<T[]> allCombinations = new List<T[]>();

        public static AlgorithmicResponse<IList<T[]>> Run(T[] input, int lengthOfCombination)
        {
            combinations = new T[lengthOfCombination];

            Combinations(0, 0, input);

            return new AlgorithmicResponse<IList<T[]>>(allCombinations, true);
        }

        private static void Combinations(int index, int startIndex,T[] input)
        {
            if (index >= combinations.Length)
            {
                allCombinations.Add(combinations.ToArray());
                return;
            }

            for (int i = startIndex; i < input.Length; i++)
            {
                combinations[index] = input[i];
                Combinations(index + 1, i,input);
            }
        }
    }
}

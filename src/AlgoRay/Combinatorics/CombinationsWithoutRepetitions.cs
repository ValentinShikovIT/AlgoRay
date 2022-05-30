using AlgoRay.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics
{
    public class CombinationsWithoutRepetitions<T>
    {
        private T[] combinations;
        private IList<T[]> allCombinations = new List<T[]>();

        public AlgorithmicResult<IList<T[]>> Run(T[] input, int lengthOfCombination)
        {
            combinations = new T[lengthOfCombination];

            Combinations(0, 0, input);

            return new AlgorithmicResult<IList<T[]>>(allCombinations, true);
        }

        private void Combinations(int index, int startIndex, T[] input)
        {
            if (index >= combinations.Length)
            {
                allCombinations.Add(combinations.ToArray());
                return;
            }

            for (int i = startIndex; i < input.Length; i++)
            {
                combinations[index] = input[i];
                Combinations(index + 1, i + 1, input);
            }
        }
    }
}

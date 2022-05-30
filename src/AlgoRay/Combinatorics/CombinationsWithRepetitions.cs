using AlgoRay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics
{
    public class CombinationsWithRepetitions<T>
    {
        private T[] combinations;
        private IList<T[]> allCombinations = new List<T[]>();

        public AlgorithmicResult<IList<T[]>> Run(T[] input, int lengthOfCombination)
        {
            try
            {
                return Logic(input, lengthOfCombination);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<IList<T[]>>(default, ex.Message);
            }
        }

        public AlgorithmicResult<IList<T[]>> Logic(T[] input, int lengthOfCombination)
        {
            combinations = new T[lengthOfCombination];

            Combinations(0, 0, input);

            return new AlgorithmicResult<IList<T[]>>(allCombinations);
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
                Combinations(index + 1, i, input);
            }
        }
    }
}

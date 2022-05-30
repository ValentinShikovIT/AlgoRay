using AlgoRay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics
{
    public class VariationsWithoutRepetitions<T>
    {
        private T[] variation;
        private bool[] used;
        private IList<T[]> allVariations = new List<T[]>();

        public AlgorithmicResult<IList<T[]>> Run(T[] input, int lengthOfVariation)
        {
            try
            {
                return Logic(input, lengthOfVariation);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<IList<T[]>>(default, ex.Message);
            }
        }

        public AlgorithmicResult<IList<T[]>> Logic(T[] input, int lengthOfVariation)
        {
            variation = new T[lengthOfVariation];
            used = new bool[input.Length];

            Variations(0, input);

            return new AlgorithmicResult<IList<T[]>>(allVariations);
        }

        private void Variations(int index, T[] input)
        {
            if (index >= variation.Length)
            {
                allVariations.Add(variation.ToArray());
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (used[i] == false)
                {
                    used[i] = true;
                    variation[index] = input[i];
                    Variations(index + 1, input);
                    used[i] = false;
                }
            }
        }
    }
}

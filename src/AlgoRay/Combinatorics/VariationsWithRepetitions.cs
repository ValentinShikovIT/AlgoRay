using AlgoRay.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics
{
    public class VariationsWithRepetitions<T>
    {
        private static T[] variation;
        private readonly static IList<T[]> allVariations = new List<T[]>();

        public static AlgorithmicResult<IList<T[]>> Run(T[] input, int lengthOfVariation)
        {
            variation = new T[lengthOfVariation];

            Variations(0, input);

            return new AlgorithmicResult<IList<T[]>>(allVariations, true);
        }

        private static void Variations(int index, T[] input)
        {
            if (index >= variation.Length)
            {
                allVariations.Add(variation.ToArray());
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                variation[index] = input[i];
                Variations(index + 1, input);
            }
        }
    }
}

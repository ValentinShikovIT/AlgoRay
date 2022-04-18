using AlgoRay.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics.Exercises
{
    public class Cinema
    {
        private static IList<string> _names = new List<string>();
        private static string[] result;
        private static bool[] locked;

        private static IList<string[]> outputResults = new List<string[]>();

        public static AlgorithmicResult<IList<string[]>> Run(IList<string> names, IDictionary<string, int> placeChanges)
        {
            _names = names;

            result = new string[names.Count];
            locked = new bool[names.Count];

            Permutations(0);

            return new AlgorithmicResult<IList<string[]>>(outputResults, true);
        }

        private static void Permutations(int index)
        {
            if (index >= _names.Count)
            {
                PrintResult(_names);
                return;
            }

            Permutations(index + 1);

            for (int i = index + 1; i < _names.Count; i++)
            {
                Swap(i, index);
                Permutations(index + 1);
                Swap(i, index);
            }
        }

        private static void Swap(int first, int second)
        {
            (_names[second], _names[first]) = (_names[first], _names[second]);
        }

        private static void PrintResult(IList<string> arr)
        {
            var arrIndex = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (locked[i] == false)
                {
                    result[i] = arr[arrIndex++];
                }
            }

            outputResults.Add(result.ToArray());
        }
    }
}

using AlgoRay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics.Exercises
{
    public class Cinema
    {
        private IList<string> _names = new List<string>();
        private string[] result;
        private bool[] locked;

        private readonly IList<string[]> outputResults = new List<string[]>();

        public AlgorithmicResult<IList<string[]>> Run(IList<string> names, IDictionary<string, int> placeChanges)
        {
            try
            {
                return Logic(names, placeChanges);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<IList<string[]>>(default, ex.Message);
            }
        }

        public AlgorithmicResult<IList<string[]>> Logic(IList<string> names, IDictionary<string, int> placeChanges)
        {
            _names = names;

            result = new string[names.Count];
            locked = new bool[names.Count];

            AdjustFixedPlaces(placeChanges);

            Permutations(0);

            return new AlgorithmicResult<IList<string[]>>
                (outputResults.Select(x => x.OrderBy(x => x).ToArray()).ToList());
        }

        private void AdjustFixedPlaces(IDictionary<string, int> placeChanges)
        {
            foreach (var changedPlace in placeChanges)
            {
                result[changedPlace.Value - 1] = changedPlace.Key;
                locked[changedPlace.Value - 1] = true;

                _names.Remove(changedPlace.Key);
            }
        }

        private void Permutations(int index)
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

        private void Swap(int first, int second)
        {
            var temp = _names[first];
            _names[first] = _names[second];
            _names[second] = temp;
        }

        private void PrintResult(IList<string> arr)
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

using AlgoRay.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics.Exercises
{
    public class WordCruncher
    {
        private string[] _wordParts;
        private string word;
        private readonly Dictionary<int, List<string>> allIndexes = new Dictionary<int, List<string>>();
        private readonly Dictionary<string, int> availableAmount = new Dictionary<string, int>();
        private readonly LinkedList<string> result = new LinkedList<string>();
        private IList<string[]> outputResults = new List<string[]>();

        public AlgorithmicResult<IList<string[]>> Run(string[] wordParts, string theWord)
        {
            _wordParts = wordParts;

            word = theWord;

            foreach (var item in _wordParts)
            {
                var foundIndexes = FindIndexes(item);

                if (availableAmount.ContainsKey(item))
                {
                    availableAmount[item]++;
                    continue;
                }
                else
                {
                    availableAmount[item] = 1;
                }

                foreach (var index in foundIndexes)
                {
                    if (allIndexes.ContainsKey(index))
                    {
                        allIndexes[index].Add(item);
                    }
                    else
                    {
                        allIndexes.Add(index, new List<string>() { item });
                    }
                }
            }

            Variation(0);

            outputResults = outputResults
                .OrderBy(word => string.Join(" ", word))
                .ToList();

            return new AlgorithmicResult<IList<string[]>>(outputResults, true);
        }

        private List<int> FindIndexes(string item)
        {
            var list = new List<int>();
            var index = 0;
            do
            {
                var indexOf = word.IndexOf(item, index);

                if (indexOf < 0)
                {
                    return list;
                }

                list.Add(indexOf);
                index = indexOf + 1;
            }
            while (index < word.Length);

            return list;
        }

        private void Variation(int index)
        {
            if (index == word.Length)
            {
                outputResults.Add(result.ToArray());
                return;
            }

            if (!allIndexes.ContainsKey(index))
            {
                return;
            }

            var listOfAvailableStrings = allIndexes[index];

            for (int i = 0; i < listOfAvailableStrings.Count; i++)
            {
                if (availableAmount[listOfAvailableStrings[i]] != 0)
                {
                    result.AddLast(listOfAvailableStrings[i]);
                    availableAmount[listOfAvailableStrings[i]]--;
                    Variation(index + listOfAvailableStrings[i].Length);
                    availableAmount[listOfAvailableStrings[i]]++;
                    result.RemoveLast();
                }
            }
        }
    }
}

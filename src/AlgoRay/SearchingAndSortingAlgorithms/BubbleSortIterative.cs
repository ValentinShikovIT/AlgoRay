using AlgoRay.Helpers;
using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public static class BubbleSortIterative
    {
        public static AlgorithmicResponse<IList<T>> Run<T>(IList<T> inputElements)
            where T : IComparable
        {
            for (int i = 0; i < inputElements.Count; i++)
            {
                var isSorted = true;

                for (int j = 0; j < inputElements.Count - 1 - i; j++)
                {
                    if (inputElements[j].CompareTo(inputElements[j + 1]) == 1)
                    {
                        isSorted = false;
                        (inputElements[j + 1], inputElements[j]) = (inputElements[j], inputElements[j + 1]);
                    }
                }

                if (isSorted)
                {
                    break;
                }
            }

            return new AlgorithmicResponse<IList<T>>(inputElements, true);
        }
    }
}
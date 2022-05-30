using AlgoRay.Helpers;
using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class SelectionSortIterative
    {
        public AlgorithmicResult<IList<T>> Run<T>(IList<T> inputElements)
            where T : IComparable
        {
            for (int i = 0; i < inputElements.Count; i++)
            {
                var indexOfMin = i;

                for (int j = i + 1; j < inputElements.Count; j++)
                {
                    if (inputElements[indexOfMin].CompareTo(inputElements[j]) == 1)
                    {
                        indexOfMin = j;
                    }
                }

                (inputElements[indexOfMin], inputElements[i]) = (inputElements[i], inputElements[indexOfMin]);
            }

            return new AlgorithmicResult<IList<T>>(inputElements, true);
        }
    }
}

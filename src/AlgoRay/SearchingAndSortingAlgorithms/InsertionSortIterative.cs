using AlgoRay.Helpers;
using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class InsertionSortIterative
    {
        public AlgorithmicResult<IList<T>> Run<T>(IList<T> inputElements)
            where T : IComparable
        {
            for (int i = 1; i < inputElements.Count; i++)
            {
                var insertionIndex = i - 1;

                while (insertionIndex >= 0 && inputElements[insertionIndex + 1].CompareTo(inputElements[insertionIndex]) == -1)
                {
                    Swap(inputElements, insertionIndex + 1, insertionIndex);
                    insertionIndex--;
                }
            }

            return new AlgorithmicResult<IList<T>>(inputElements, true);
        }

        private void Swap<T>(IList<T> inputElements, int first, int second)
            => (inputElements[second], inputElements[first]) = (inputElements[first], inputElements[second]);
    }
}

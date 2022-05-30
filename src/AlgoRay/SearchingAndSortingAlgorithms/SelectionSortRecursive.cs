using AlgoRay.Helpers;
using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class SelectionSortRecursive
    {
        public AlgorithmicResult<IList<T>> Run<T>(IList<T> inputElements)
            where T : IComparable
        {
            try
            {
                return Logic(inputElements);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<IList<T>>(default, ex.Message);
            }
        }

        public AlgorithmicResult<IList<T>> Logic<T>(IList<T> inputElements)
            where T : IComparable
        {
            for (int i = 0; i < inputElements.Count; i++)
            {
                Recursion(inputElements, i, i + 1, i);
            }

            return new AlgorithmicResult<IList<T>>(inputElements);
        }

        private void Recursion<T>(IList<T> inputElements, int startingIndex, int currentIndex, int indexOfMin)
            where T : IComparable
        {
            if (currentIndex >= inputElements.Count)
            {
                (inputElements[indexOfMin], inputElements[startingIndex]) = (inputElements[startingIndex], inputElements[indexOfMin]);
                return;
            }

            if (inputElements[indexOfMin].CompareTo(inputElements[currentIndex]) == 1)
            {
                indexOfMin = currentIndex;
            }

            Recursion(inputElements, startingIndex, currentIndex + 1, indexOfMin);
        }
    }
}

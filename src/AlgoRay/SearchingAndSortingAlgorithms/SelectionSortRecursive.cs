using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class SelectionSortRecursive
    {
        public static AlgorithmicResponse<T> Run<T>(IList<T> inputElements)
            where T : IComparable
        {
            for (int i = 0; i < inputElements.Count; i++)
            {
                Recursion(inputElements, i, i + 1, i);
            }

            return new AlgorithmicResponse<T>(inputElements, true);
        }

        private static void Recursion<T>(IList<T> inputElements, int startingIndex, int currentIndex, int indexOfMin)
            where T : IComparable
        {
            if(currentIndex >= inputElements.Count)
            {
                (inputElements[indexOfMin], inputElements[startingIndex]) = (inputElements[startingIndex], inputElements[indexOfMin]);
                return;
            }

            if(inputElements[indexOfMin].CompareTo(inputElements[currentIndex]) == 1)
            {
                indexOfMin = currentIndex;
            }

            Recursion(inputElements, startingIndex, currentIndex + 1, indexOfMin);
        }
    }
}

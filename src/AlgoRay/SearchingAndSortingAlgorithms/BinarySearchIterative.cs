using AlgoRay.Helpers;
using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingAndSortingAlgorithms
{
    /// <summary>
    /// Binary Search returns an algorithmic response with the index of the searched element
    /// as a response.
    /// If the element is not found returns -1 as the result
    /// </summary>
    public static class BinarySearchIterative
    {
        public static new AlgorithmicResponse<int> Run<T>(IList<T> sortedInput, T searchedItem)
            where T : IComparable
        {
            var leftPointer = 0;
            var rightPointer = sortedInput.Count - 1;

            while (leftPointer <= rightPointer)
            {
                var middlePointer = (rightPointer + leftPointer) / 2;

                if (sortedInput[middlePointer].Equals(searchedItem))
                {
                    return new AlgorithmicResponse<int>(middlePointer, true);
                }

                if (searchedItem.CompareTo(sortedInput[middlePointer]) == 1)
                {
                    leftPointer = middlePointer + 1;
                }
                else
                {
                    rightPointer = middlePointer - 1;
                }
            }

            return new AlgorithmicResponse<int>(-1, false);
        }
    }
}

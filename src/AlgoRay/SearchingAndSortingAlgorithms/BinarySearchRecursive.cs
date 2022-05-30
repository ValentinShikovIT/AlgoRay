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
    public class BinarySearchRecursive
    {
        public AlgorithmicResult<int?> Run<T>(IList<T> sortedInput, T searchedItem)
            where T : IComparable
        {
            try
            {
                return Logic(sortedInput, searchedItem);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<int?>(default, ex.Message);
            }
        }

        public AlgorithmicResult<int?> Logic<T>(IList<T> sortedInput, T searchedItem)
            where T : IComparable
        {
            var resultingIndex = Recursion(sortedInput, searchedItem, 0, sortedInput.Count - 1);

            return new AlgorithmicResult<int?>(resultingIndex);
        }

        private int Recursion<T>(IList<T> sortedInput,
            T searchedItem,
            int leftPointer,
            int rightPointer)
            where T : IComparable
        {
            var middlePointer = (leftPointer + rightPointer) / 2;

            if (sortedInput[middlePointer].Equals(searchedItem))
            {
                return middlePointer;
            }

            if (leftPointer > rightPointer)
            {
                return -1;
            }

            if (searchedItem.CompareTo(sortedInput[middlePointer]) == 1)
            {
                return Recursion(sortedInput, searchedItem, middlePointer + 1, rightPointer);
            }
            else
            {
                return Recursion(sortedInput, searchedItem, leftPointer, middlePointer - 1);
            }
        }
    }
}

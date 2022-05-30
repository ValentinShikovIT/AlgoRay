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
    public class BinarySearchIterative
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

        private AlgorithmicResult<int?> Logic<T>(IList<T> sortedInput, T searchedItem)
            where T : IComparable
        {
            var leftPointer = 0;
            var rightPointer = sortedInput.Count - 1;

            while (leftPointer <= rightPointer)
            {
                var middlePointer = (rightPointer + leftPointer) / 2;

                if (sortedInput[middlePointer].Equals(searchedItem))
                {
                    return new AlgorithmicResult<int?>(middlePointer);
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

            return new AlgorithmicResult<int?>(-1);
        }
    }
}

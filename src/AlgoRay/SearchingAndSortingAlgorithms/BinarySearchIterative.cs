using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingAndSortingAlgorithms
{
    public static class BinarySearchIterative
    {
        public static (T result, bool isFound) Run<T>(IList<T> sortedInput, T searchedItem)
            where T : IComparable
        {
            var leftPointer = 0;
            var rightPointer = sortedInput.Count - 1;

            while (leftPointer <= rightPointer)
            {
                var middlePointer = (rightPointer + leftPointer) / 2;

                if (sortedInput[middlePointer].Equals(searchedItem))
                {
                    return (sortedInput[middlePointer], true);
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

            return (default, false);
        }
    }
}

using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingAndSortingAlgorithms
{
    public static class BinarySearchIterative
    {
        public static int Run<T>(IList<T> sortedInput, T searchedItem)
            where T : IComparable
        {
            var leftPointer = 0;
            var rightPointer = sortedInput.Count - 1;

            while (leftPointer <= rightPointer)
            {
                var middlePointer = (rightPointer + leftPointer) / 2;

                if (sortedInput[middlePointer].Equals(searchedItem))
                {
                    return middlePointer;
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

            return -1;
        }
    }
}

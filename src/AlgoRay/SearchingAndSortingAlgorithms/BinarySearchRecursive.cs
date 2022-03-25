using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingAndSortingAlgorithms
{
    public static class BinarySearchRecursive
    {
        public static int Run<T>(IList<T> sortedInput, T searchedItem)
            where T : IComparable
            => Recursion<T>(sortedInput, searchedItem, 0, sortedInput.Count - 1);

        private static int Recursion<T>(IList<T> sortedInput,
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
                return Recursion(sortedInput, searchedItem, leftPointer, rightPointer - 1);
            }
        }
    }
}

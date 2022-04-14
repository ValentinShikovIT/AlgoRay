using AlgoRay.Helpers;
using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public static class QuickSortRecursive
    {
        //Implement Quick sort algorithm without O(log n) memory optimization
        public static AlgorithmicResult<IList<T>> Run<T>(IList<T> inputElements)
            where T : IComparable
        {
            Recursion(inputElements, 0, inputElements.Count - 1);

            return new AlgorithmicResult<IList<T>>(inputElements, true);
        }

        private static void Recursion<T>(IList<T> inputElements, int start, int end)
            where T : IComparable
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (inputElements[left].CompareTo(inputElements[pivot]) == 1 &&
                    inputElements[right].CompareTo(inputElements[pivot]) == -1)
                {
                    Swap(inputElements, left, right);
                }

                if (inputElements[left].CompareTo(inputElements[pivot]) <= 0)
                {
                    left++;
                }

                if (inputElements[right].CompareTo(inputElements[pivot]) >= 0)
                {
                    right--;
                }
            }

            Swap(inputElements, pivot, right);
            Recursion(inputElements, start, right - 1);
            Recursion(inputElements, right + 1, end);
        }

        private static void Swap<T>(IList<T> inputElements, int first, int second)
            where T : IComparable
            => (inputElements[second], inputElements[first]) = (inputElements[first], inputElements[second]);
    }
}

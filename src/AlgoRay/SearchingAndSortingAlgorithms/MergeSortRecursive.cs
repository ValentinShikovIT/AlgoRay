﻿using AlgoRay.Helpers;
using System;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class MergeSortRecursive
    {
        public AlgorithmicResult<T[]> Run<T>(T[] inputElements)
            where T : IComparable
        {
            try
            {
                return Logic(inputElements);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<T[]>(default, ex.Message);
            }
        }

        public AlgorithmicResult<T[]> Logic<T>(T[] inputElements)
            where T : IComparable
        {
            if (inputElements.Length <= 1)
            {
                return new AlgorithmicResult<T[]>(inputElements);
            }

            var copy = new T[inputElements.Length];

            Array.Copy(inputElements, copy, inputElements.Length);

            MergeSortHelper(inputElements, copy, 0, inputElements.Length - 1);

            return new AlgorithmicResult<T[]>(inputElements);
        }

        private void MergeSortHelper<T>(T[] source, T[] copy, int leftIndex, int rightIndex)
            where T : IComparable
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            var middleIndex = (leftIndex + rightIndex) / 2;

            MergeSortHelper(copy, source, leftIndex, middleIndex);
            MergeSortHelper(copy, source, middleIndex + 1, rightIndex);

            Merge(source, copy, leftIndex, middleIndex, rightIndex);
        }

        private void Merge<T>(T[] source, T[] copy, int leftIndex, int middleIndex, int rightIndex)
            where T : IComparable
        {
            var sourcePointer = leftIndex;
            var leftPointer = leftIndex;
            var rightPointer = middleIndex + 1;

            while (leftPointer <= middleIndex && rightPointer <= rightIndex)
            {
                if (copy[leftPointer].CompareTo(copy[rightPointer]) == -1)
                {
                    source[sourcePointer++] = copy[leftPointer++];
                }
                else
                {
                    source[sourcePointer++] = copy[rightPointer++];
                }
            }

            for (int i = leftPointer; i <= middleIndex; i++)
            {
                source[sourcePointer++] = copy[i];
            }

            for (int i = rightPointer; i <= rightIndex; i++)
            {
                source[sourcePointer++] = copy[i];
            }
        }
    }
}

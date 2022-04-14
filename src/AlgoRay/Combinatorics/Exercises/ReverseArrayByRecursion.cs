﻿using AlgoRay.Helpers;

namespace AlgoRay.Combinatorics.Exercises
{
    public class ReverseArrayByRecursion<T>
    {
        private static T[] reversedArray;

        public static AlgorithmicResult<T[]> Run(T[] arr)
        {
            reversedArray = new T[arr.Length];

            ReverseArray(arr, 0);

            return new AlgorithmicResult<T[]>(reversedArray, true);
        }

        private static void ReverseArray(T[] arr, int index)
        {
            if (index >= arr.Length)
            {
                return;
            }

            reversedArray[index] = arr[arr.Length - 1 - index];

            ReverseArray(arr, index + 1);
        }
    }
}
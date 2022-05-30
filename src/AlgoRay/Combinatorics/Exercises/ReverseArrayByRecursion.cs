using AlgoRay.Helpers;
using System;

namespace AlgoRay.Combinatorics.Exercises
{
    public class ReverseArrayByRecursion<T>
    {
        private T[] reversedArray;

        public AlgorithmicResult<T[]> Run(T[] arr)
        {
            try
            {
                return Logic(arr);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<T[]>(default, ex.Message);
            }
        }

        public AlgorithmicResult<T[]> Logic(T[] arr)
        {
            reversedArray = new T[arr.Length];

            ReverseArray(arr, 0);

            return new AlgorithmicResult<T[]>(reversedArray);
        }

        private void ReverseArray(T[] arr, int index)
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

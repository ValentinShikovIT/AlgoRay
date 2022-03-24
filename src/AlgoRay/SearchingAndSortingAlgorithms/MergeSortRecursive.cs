using System;
using System.Linq;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class MergeSortRecursive
    {
        private static int[] numbers;

        public static void Main(string[] args)
        {
            //Read the input from the console
            numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            //Implement the MergeSort with O(n) memory algorithm
            var result = Implementation(numbers);

            //Print the result
            Console.WriteLine(string.Join(' ', result));
        }

        private static int[] Implementation(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            var copy = new int[array.Length];

            Array.Copy(array, copy, array.Length);

            MergeSortHelper(array, copy, 0, array.Length - 1);

            return array;
        }

        private static void MergeSortHelper(int[] source, int[] copy, int leftIndex, int rightIndex)
        {
            if(leftIndex >= rightIndex)
            {
                return;
            }

            var middleIndex = (leftIndex + rightIndex) / 2;

            MergeSortHelper(copy, source, leftIndex, middleIndex);
            MergeSortHelper(copy, source, middleIndex + 1, rightIndex);

            Merge(source, copy, leftIndex, middleIndex, rightIndex);
        }

        private static void Merge(int[] source, int[] copy, int leftIndex, int middleIndex, int rightIndex)
        {
            var sourcePointer = leftIndex;
            var leftPointer = leftIndex;
            var rightPointer = middleIndex + 1;

            while(leftPointer <= middleIndex && rightPointer <= rightIndex)
            {
                if(copy[leftPointer] < copy[rightPointer])
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

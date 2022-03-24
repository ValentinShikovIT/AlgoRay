using System;
using System.Linq;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class QuickSortRecursive
    {
        private static int[] numbers;

        public static void Main(string[] args)
        {
            //Read input from the console
            numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            //Implement Quick sort algorithm without O(log n) memory optimization
            Implementation(0, numbers.Length -1);

            //Print the result
            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void Implementation(int start, int end)
        {
            if(start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while(left <= right)
            {
                if(numbers[left] > numbers[pivot] &&
                    numbers[right] < numbers[pivot])
                {
                    Swap(left, right);
                }

                if(numbers[left] <= numbers[pivot])
                {
                    left++;
                }

                if(numbers[right] >= numbers[pivot])
                {
                    right--;
                }
            }

            Swap(pivot, right);
            Implementation(start, right - 1);
            Implementation(right + 1, end);
        }

        private static void Swap(int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}

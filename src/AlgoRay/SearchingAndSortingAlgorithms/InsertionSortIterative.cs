using System;
using System.Linq;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class InsertionSortIterative
    {
        private static int[] numbers;

        public static void Main(string[] args)
        {
            //Read from the console
            numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            //Implement the InsertionSort algorithm
            Implementation();

            //Print the sorted numbers
            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void Implementation()
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                var insertionIndex = i - 1;

                while(insertionIndex >= 0 && numbers[insertionIndex + 1] < numbers[insertionIndex])
                {
                    Swap(insertionIndex + 1, insertionIndex);
                    insertionIndex--;
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}

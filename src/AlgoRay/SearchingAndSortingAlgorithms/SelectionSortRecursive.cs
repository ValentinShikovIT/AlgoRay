using System;
using System.Linq;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class SelectionSortRecursive
    {
        private static int[] numbers;

        public static void Main(string[] args)
        {
            //Gather inputs
            numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            //Implement sorting Algorithm using recursion
            for (int i = 0; i < numbers.Length; i++)
            {
                Implementation(i, i + 1, i);
            }

            //Print
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Implementation(int startingIndex, int currentIndex, int indexOfMin)
        {
            if(currentIndex >= numbers.Length)
            {
                var temp = numbers[startingIndex];
                numbers[startingIndex] = numbers[indexOfMin];
                numbers[indexOfMin] = temp;

                return;
            }

            if(numbers[indexOfMin] > numbers[currentIndex])
            {
                indexOfMin = currentIndex;
            }

            Implementation(startingIndex, currentIndex + 1, indexOfMin);
        }
    }
}

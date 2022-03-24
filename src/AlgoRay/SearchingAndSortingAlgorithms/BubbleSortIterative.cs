using System;
using System.Linq;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class BubbleSortIterative
    {
        private static int[] numbers;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Implementation();

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void Implementation()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var isSorted = true;

                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        isSorted = false;
                        var temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }

                if (isSorted)
                {
                    return;
                }
            }
        }
    }
}
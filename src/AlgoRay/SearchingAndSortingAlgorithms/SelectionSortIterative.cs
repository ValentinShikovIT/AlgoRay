using System;
using System.Linq;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class SelectionSortIterative
    {
        private static int[] numbers;

        public static void Main(string[] args)
        {
            //Gather inputs
            numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            //Implement sorting Algorithm
            Implementation();

            //Print
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Implementation()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var indexOfMin = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if(numbers[indexOfMin] > numbers[j])
                    {
                        indexOfMin = j;
                    }
                }

                var temp = numbers[i];
                numbers[i] = numbers[indexOfMin];
                numbers[indexOfMin] = temp;
            }
        }
    }
}

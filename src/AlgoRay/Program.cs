using AlgoRay.SearchingAndSortingAlgorithms;
using System;

namespace AlgoRay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            var foundNum = new BinarySearchRecursive().Run(arr, 8);

            Console.WriteLine(foundNum);
        }
    }
}

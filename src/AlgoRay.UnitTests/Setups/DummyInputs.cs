using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.Setups
{
    public static class DummyInputs
    {
        /// <summary>
        /// Generated random elements sorted in the range [0 ; 50 000]
        /// </summary>
        public static IList<int> BinarySearch_1 { get; } = GetDummyNumbersForBinarySearchTest_1();

        /// <summary>
        /// Generated random elements unsorted in range [0 ; 50 000]
        /// Numbers in the collection 5000
        /// </summary>
        public static IList<int> UnsortedDummyData_Small { get; } = GetDummyNumbersForSortingAlgorithm_SmallAmount();

        /// <summary>
        /// Generated random elements unsorted in range [0 ; 50 000]
        /// Numbers in the collection 25000 
        /// </summary>
        public static IList<int> UnsortedDummyData_Medium { get; } = GetDummyNumbersForSortingAlgorithm_MediumAmount();

        /// <summary>
        /// Generated random elements unsorted in range [0 ; 50 000]
        /// Numbers in the collection 50 000
        /// </summary>
        public static IList<int> UnsortedDummyData_Big { get; } = GetDummyNumbersForSortingAlgorithm_BigAmount();

        public static string[] RandomStringsFor_PermutationWithoutRepetitionTest_1 = new string[] { "A", "B", "C" };

        private static IList<int> GetDummyNumbersForSortingAlgorithm_SmallAmount()
        {
            var list = new List<int>();

            for (int i = 0; i < 5_000; i++)
            {
                var random = new Random().Next(0, 50_000);

                list.Add(random);
            }

            return list;
        }

        private static IList<int> GetDummyNumbersForSortingAlgorithm_MediumAmount()
        {
            var list = new List<int>();

            for (int i = 0; i < 25_000; i++)
            {
                var random = new Random().Next(0, 50_000);

                list.Add(random);
            }

            return list;
        }

        private static IList<int> GetDummyNumbersForSortingAlgorithm_BigAmount()
        {
            var list = new List<int>();

            for (int i = 0; i < 50_000; i++)
            {
                var random = new Random().Next(0, 50_000);

                list.Add(random);
            }

            return list;
        }

        private static IList<int> GetDummyNumbersForBinarySearchTest_1()
        {
            var set = new HashSet<int>();

            for (int i = 0; i < 50_000; i++)
            {
                var random = new Random().Next(0, 50_000);

                set.Add(random);
            }

            return set
                .OrderBy(x => x)
                .ToList();
        }
    }
}

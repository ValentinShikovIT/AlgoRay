using System.Collections.Generic;

namespace AlgoRay.UnitTests.Setups
{
    internal class DummyOutputs
    {
        // Sorting
        public static IList<int> SortedData_Small { get; } = GetOrderedNumbersForSortingAlgorithm_SmallAmount();
        public static IList<int> SortedData_Medium { get; } = GetOrderedNumbersForSortingAlgorithm_MediumAmount();
        public static IList<int> SortedData_Large { get; } = GetOrderedNumbersForSortingAlgorithm_BigAmount();

        // Pemutations
        public static List<string[]> Expected_PermutationWithoutRepetition_1 { get; } = new List<string[]>
        {
            new string[] {"A", "B", "C"},
            new string[] {"A", "C", "B"},
            new string[] {"B", "A", "C"},
            new string[] {"B", "C", "A"},
            new string[] {"C", "A", "B"},
            new string[] {"C", "B", "A"},
        };

        public static List<string[]> Expected_PermutationWithRepetition_1 { get; } = new List<string[]>
        {
            new string[] {"A", "B", "B"},
            new string[] {"B", "A", "B"},
            new string[] {"B", "B", "A"},
        };

        // Methods
        private static IList<int> GetOrderedNumbersForSortingAlgorithm_SmallAmount()
        {
            var list = new List<int>();

            for (int i = 0; i < 5_000; i++)
            {
                list.Add(1);
            }

            return list;
        }

        private static IList<int> GetOrderedNumbersForSortingAlgorithm_MediumAmount()
        {
            var list = new List<int>();

            for (int i = 0; i < 25_000; i++)
            {
                list.Add(1);
            }

            return list;
        }

        private static IList<int> GetOrderedNumbersForSortingAlgorithm_BigAmount()
        {
            var list = new List<int>();

            for (int i = 0; i < 50_000; i++)
            {
                list.Add(1);
            }

            return list;
        }
    }
}

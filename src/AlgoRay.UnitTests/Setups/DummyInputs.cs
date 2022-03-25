using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.Setups
{
    public static class DummyInputs
    {
        public static IList<int> BinarySearch_1 { get; }

        static DummyInputs()
        {
            BinarySearch_1 = GetDummyNumbersForBinarySearchTest_1();
        }

        private static IList<int> GetDummyNumbersForBinarySearchTest_1()
        {
            var set = new HashSet<int>();

            for (int i = 0; i < 50_000; i++)
            {
                var random = new Random().Next(int.MinValue, int.MaxValue);

                set.Add(random);
            }

            return set
                .OrderBy(x => x)
                .ToList();
        }
    }
}

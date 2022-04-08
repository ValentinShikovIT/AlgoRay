using AlgoRay.Helpers;
using AlgoRay.UnitTests.Setups;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.Helpers
{
    public abstract class TestsBase
    {
        public void AssertTestResultFromAlgorithmicResponse<T>(
            TestResult<AlgorithmicResponse<T>> result, 
            ICollection<T> expected,
            bool orderExpected = true,
            bool orderActual = true)
        {
            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.IsTrue(result.Value.IsSuccessful);

            T[] expectedAsOrderedArray = null;
            T[] resultAsOrderedArray = null;
            if (orderExpected)
            {
                expectedAsOrderedArray = expected.OrderBy(x => x).ToArray();
            }

            if (orderActual)
            {
                resultAsOrderedArray = result.Value.AlgorithmResult.OrderBy(x => x).ToArray();
            }

            expectedAsOrderedArray.ShouldDeepEqual(resultAsOrderedArray);
        }

        public void AssertTestResultFromAlgorithmicResponse<T>(
            TestResult<AlgorithmicResponse<T[]>> result, 
            ICollection<T[]> expected,
            bool orderExpected = true,
            bool orderActual = true)
        {
            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.IsTrue(result.Value.IsSuccessful);

            T[][] expectedAsOrderedArray = null;
            T[][] resultAsOrderedArray = null;
            if (orderExpected)
            {
                expectedAsOrderedArray = expected
                .Select(arr => arr.OrderBy(x => x).ToArray())
                .ToArray();
            }
            if (orderActual)
            {
                resultAsOrderedArray = result.Value.AlgorithmResult
                    .Select(arr => arr.OrderBy(x => x).ToArray())
                    .ToArray();
            }

            expectedAsOrderedArray.ShouldDeepEqual(resultAsOrderedArray);
        }
    }
}

using AlgoRay.Helpers;
using AlgoRay.UnitTests.Setups;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.Helpers
{
    public abstract class CollectionsTest
    {
        public void AssertTestResultFromTestRunningResponse<T>(
            TestResult<AlgorithmicResult<IList<T>>> result,
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

        public void AssertTestResultFromTestRunningResponse<T>(
            TestResult<AlgorithmicResult<IList<T[]>>> result,
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

        public void AssertTestResultFromTestRunningResponse<T>(
            TestResult<AlgorithmicResult<T[]>> result,
            ICollection<T> expected,
            bool orderExpected = true,
            bool orderActual = true)
            => AssertTestResultFromTestRunningResponse(
                new TestResult<AlgorithmicResult<IList<T>>>(result.IsInTimeLimit,
                    new AlgorithmicResult<IList<T>>(result.Value.AlgorithmResult.ToList(), result.Value.IsSuccessful)),
                expected,
                orderExpected,
                orderActual);

        public void AssertTestResultFromTestRunningResponse<T>(
            TestResult<AlgorithmicResult<T>> result,
            T expected)
            where T : IComparable
        {
            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.IsTrue(result.Value.IsSuccessful);

            Assert.AreEqual(result.Value.AlgorithmResult, expected);
        }
    }
}

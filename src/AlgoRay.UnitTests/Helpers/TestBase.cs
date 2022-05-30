using AlgoRay.Helpers;
using AlgoRay.UnitTests.Setups;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.Helpers
{
    public abstract class TestBase
    {
        public void AssertTestResultFromTestRunningResponse<T>(
            TestResult<AlgorithmicResult<IList<T>>> result,
            ICollection<T> expected)
        {
            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.AreEqual(result.Value.ExceptionMessage, null);

            result.Value.AlgorithmResult.ShouldDeepEqual(expected);
        }

        public void AssertTestResultFromTestRunningResponse<T>(
            TestResult<AlgorithmicResult<IList<T[]>>> result,
            ICollection<T[]> expected)
        {
            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.AreEqual(result.Value.ExceptionMessage, null);

            result.Value.AlgorithmResult.ShouldDeepEqual(expected);
        }

        public void AssertTestResultFromTestRunningResponse<T>(
            TestResult<AlgorithmicResult<T[]>> result,
            ICollection<T> expected)
            => AssertTestResultFromTestRunningResponse(
                new TestResult<AlgorithmicResult<IList<T>>>(result.IsInTimeLimit,
                    new AlgorithmicResult<IList<T>>(result.Value.AlgorithmResult.ToList(), result.Value.ExceptionMessage)),
                expected);

        public void AssertTestResultFromTestRunningResponse<T>(
            TestResult<AlgorithmicResult<T>> result,
            T expected)
            where T : IComparable
        {
            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.AreEqual(result.Value.ExceptionMessage, null);

            Assert.AreEqual(expected, result.Value.AlgorithmResult);
        }
    }
}

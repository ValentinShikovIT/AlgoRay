using System;

namespace AlgoRay.UnitTests.Helpers
{
    public class TestResult<T>
    {
        public TestResult(bool isInTimeLimit, T result)
        {
            this.IsInTimeLimit = isInTimeLimit;
            this.Value = result;
        }

        public bool IsInTimeLimit { get; }

        public T Value { get; }
    }
}

using System;
using System.Diagnostics;

namespace AlgoRay.UnitTests.Helpers
{
    public class TestRunner
    {
        public static TestResult<T> RunTest<T>(Func<T> algortihm, int allowedRunningTimeInMilliseconds)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var result = algortihm.Invoke();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds <= allowedRunningTimeInMilliseconds ?
                new TestResult<T>(true, result) : new TestResult<T>(false, result);
        }
    }
}

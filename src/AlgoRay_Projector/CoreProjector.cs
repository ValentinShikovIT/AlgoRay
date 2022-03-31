using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;

namespace AlgoRay_Projector
{
    internal static class CoreProjector
    {
        public static Stopwatch ProjectTest(Action testMethod, int millisecondsTimeout)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var newThread = new Thread(() => testMethod.Invoke());

            newThread.Start();
            var hasBeenCancelledByJoin = !newThread.Join(millisecondsTimeout);

            stopwatch.Stop();

            if (hasBeenCancelledByJoin)
            {
                throw new Exception("Test timed out!", new AssertFailedException("Test timed out and took too long to run!"));
            }

            return stopwatch;
        }
    }
}

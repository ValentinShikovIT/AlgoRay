using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoRay_Projector
{
    internal static class CoreProjector
    {
        public static async Task<Stopwatch> ProjectTest(Action testMethod, int millisecondsTimeout)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(millisecondsTimeout);

            var newTask = new Task(() => testMethod.Invoke(), cancellationTokenSource.Token);
            newTask.Start();
            await newTask;

            stopwatch.Stop();

            if (newTask.IsCanceled)
            {
                throw new Exception("Test timed out!", new AssertFailedException("Test timed out and took too long to run!"));
            }

            return stopwatch;
        }
    }
}

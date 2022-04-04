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

            using (var cancellationTokenSource = new CancellationTokenSource(millisecondsTimeout))
            {
                var newTask = new Task(() =>
                {
                    testMethod.Invoke();
                },
                cancellationTokenSource.Token);

                await newTask.TryTimeOutTaskAsync(cancellationTokenSource);
            }

            stopwatch.Stop();

            return stopwatch;
        }

        private static async Task TryTimeOutTaskAsync(this Task task, CancellationTokenSource cancel)
        {
            task.Start();

            while (!task.IsCompleted)
            {
                if (cancel.IsCancellationRequested)
                {
                    throw new TimeoutException("Test timed out and took too long to run!");
                }
            }

            await task;
        }
    }
}

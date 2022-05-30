using AlgoRay_Projector.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoRay_Projector.ProjectorFunctionality
{
    internal class CoreProjector : ICoreProjector
    {
        public async Task<Stopwatch> ProjectTest(Action testMethod, int millisecondsTimeout)
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

                await TryTimeOutTaskAsync(newTask, cancellationTokenSource);
            }

            stopwatch.Stop();

            return stopwatch;
        }

        private async Task TryTimeOutTaskAsync(Task task, CancellationTokenSource cancel)
        {
            task.Start();

            while (!task.IsCompleted)
            {
                if (cancel.IsCancellationRequested)
                {
                    throw new TimeoutException("Test timed out and took too long to complete!");
                }
            }

            await task;
        }
    }
}

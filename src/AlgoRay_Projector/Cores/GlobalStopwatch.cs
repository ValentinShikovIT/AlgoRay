using AlgoRay_Projector.Interfaces;
using System.Diagnostics;

namespace AlgoRay_Projector.Cores
{
    internal class GlobalStopwatch : IStopwatch
    {
        private Stopwatch stopwatch;

        public GlobalStopwatch()
        {
            stopwatch = new Stopwatch();
        }

        public Stopwatch GetStopwatch()
            => stopwatch;

        public void Start()
            => stopwatch.Start();

        public void Stop()
            => stopwatch.Stop();
    }
}

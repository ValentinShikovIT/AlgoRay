using System.Diagnostics;

namespace AlgoRay_Projector.Interfaces
{
    internal interface IStopwatch
    {
        public void Start();

        public void Stop();

        public Stopwatch GetStopwatch();
    }
}

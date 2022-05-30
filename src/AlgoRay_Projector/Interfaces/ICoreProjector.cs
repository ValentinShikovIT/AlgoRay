using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AlgoRay_Projector.Interfaces
{
    internal interface ICoreProjector
    {
        public Task<Stopwatch> ProjectTest(Action testMethod, int millisecondsTimeout);
    }
}

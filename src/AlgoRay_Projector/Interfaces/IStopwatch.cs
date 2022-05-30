using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AlgoRay_Projector.Interfaces
{
    internal interface IStopwatch
    {
        public void Start();

        public void Stop();

        public Stopwatch GetStopwatch();
    }
}

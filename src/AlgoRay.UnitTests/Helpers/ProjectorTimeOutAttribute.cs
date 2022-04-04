using System;

namespace AlgoRay.UnitTests.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ProjectorTimeOutAttribute : Attribute
    {
        public ProjectorTimeOutAttribute(int timeoutTimeInMilliseconds)
        {
            this.TimeoutTimeInMilliseconds = timeoutTimeInMilliseconds;
        }

        public int TimeoutTimeInMilliseconds { get; }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgoRay_Projector.Interfaces
{
    internal interface IUiManager
    {
        public void PrintAssertFailedExceptionMessage(
            AssertFailedException exception,
            string testName,
            int testNumber);

        public void PrintGeneralExceptionMessage(
            Exception exception,
            string testName,
            int testNumber);

        public void PrintAssertSuccessfullMessage(
            string testName,
            int testNumber,
            long testRuntimeInMilliseconds);

        public void PrintEndingMessages(int succededTests, int failedTests, double elapsedSeconds);

        public void PrintStartingMessages();
    }
}

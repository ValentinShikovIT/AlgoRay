using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoRay_Projector
{
    internal class UiManager
    {
        public void PrintAssertFailedExceptionMessage(
            AssertFailedException exception,
            string testName,
            int testNumber)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"!! Test № {testNumber} with name {testName} failed! Message: '{exception.Message}' !!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintGeneralExceptionMessage(
            Exception exception,
            string testName,
            int testNumber)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"!! Test № {testNumber} with name {testName} generated an exception! Exception Message: '{exception.Message}' !!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintAssertSuccessfullMessage(
            string testName,
            int testNumber,
            long testRuntimeInMilliseconds)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"|| Test № {testNumber} | '{testName}' passed successfully in {testRuntimeInMilliseconds}ms. ||");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintEndingMessages(int succededTests, int failedTests, double elapsedSeconds)
        {
            Console.ForegroundColor = failedTests > 0 ?
                ConsoleColor.Yellow : ConsoleColor.DarkGreen;

            Console.WriteLine($"Testing finished with {succededTests} successful tests and {failedTests} failed tests!");
            Console.WriteLine($"Testing was finished in {elapsedSeconds} s.");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintStartingMessages()
        {
            Console.WriteLine($"Testing run beginning...   Date: {DateTime.Now:f}");
            Console.WriteLine(new string('_', 100));
            Console.WriteLine();
        }
    }
}

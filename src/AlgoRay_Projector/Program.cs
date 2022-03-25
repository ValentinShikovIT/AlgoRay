using AlgoRay.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AlgoRay_Projector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintStartingMessages();

            var globalStopwatch = new Stopwatch();
            globalStopwatch.Start();

            var allTestMethods = GetAllTestMethodsFromTestingAssembly(typeof(TestRunner));

            int testNumber = 1;
            int failedTests = 0;
            int succededTests = 0;

            Console.WriteLine(new string('-', 100));
            foreach (var testMethod in allTestMethods)
            {
                var instance = Activator.CreateInstance(testMethod.DeclaringType);

                try
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();

                    testMethod.Invoke(instance, new object[0]);

                    stopwatch.Stop();

                    PrintAssertSuccessfullMessage(testMethod.Name, testNumber, stopwatch.ElapsedMilliseconds);

                    succededTests++;
                }
                catch (Exception generalException)
                {
                    if (generalException?.InnerException is AssertFailedException assertFailedException)
                    {
                        PrintAssertFailedExceptionMessage(assertFailedException, testMethod.Name, testNumber);
                        failedTests++;
                    }
                    else
                    {
                        PrintGeneralExceptionMessage(generalException, testMethod.Name, testNumber);
                        failedTests++;
                    }
                }
                finally
                {
                    Console.WriteLine(new string('-', 100));
                }

                testNumber++;
            }
            Console.WriteLine();
            Console.WriteLine(new string('_', 100));


            globalStopwatch.Stop();

            PrintEndingMessages(succededTests, failedTests, globalStopwatch.Elapsed.TotalSeconds);
        }

        private static void PrintAssertFailedExceptionMessage(
            AssertFailedException exception,
            string testName,
            int testNumber)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"!! Test № {testNumber} with name {testName} failed! Message: '{exception.Message}' !!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintGeneralExceptionMessage(
            Exception exception,
            string testName,
            int testNumber)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"!! Test № {testNumber} with name {testName} generated an exception! Exception Message: '{exception.Message}' !!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintAssertSuccessfullMessage(
            string testName,
            int testNumber,
            long testRuntimeInMilliseconds)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"|| Test № {testNumber} | '{testName}' passed successfully in {testRuntimeInMilliseconds}ms. ||");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static MethodInfo[] GetAllTestMethodsFromTestingAssembly(Type testRunner)
            => Assembly
                .GetAssembly(testRunner)
                .GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(TestMethodAttribute), false).Length > 0)
                .ToArray();

        private static void PrintEndingMessages(int succededTests, int failedTests, double elapsedSeconds)
        {
            Console.ForegroundColor = failedTests > 0 ?
                ConsoleColor.Yellow : ConsoleColor.Green;

            Console.WriteLine($"Testing finished with {succededTests} successful tests and {failedTests} failed tests!");
            Console.WriteLine($"Testing was finished in {elapsedSeconds}s.");
        }

        private static void PrintStartingMessages()
        {
            Console.WriteLine($"Testing run beginning...   Date: {DateTime.Now:f}");
            Console.WriteLine(new string('_', 100));
            Console.WriteLine();
        }
    }
}

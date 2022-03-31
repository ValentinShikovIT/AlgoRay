using AlgoRay.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AlgoRay_Projector
{
    internal class Program
    {
        private static readonly TestInitilizers _initializers = new TestInitilizers();
        private static readonly UiManager _uiManager = new UiManager();

        static void Main(string[] args)
        {
            _uiManager.PrintStartingMessages();

            var globalStopwatch = new Stopwatch();
            globalStopwatch.Start();

            var allTestMethods = GetAllTestMethodsFromTestingAssembly(typeof(TestRunner));

            int testNumber = 1;
            int failedTests = 0;
            int succededTests = 0;

            Console.WriteLine(new string('-', 100));

            MainLogic(allTestMethods, succededTests, testNumber, failedTests);

            Console.WriteLine();
            Console.WriteLine(new string('_', 100));


            globalStopwatch.Stop();

            _uiManager.PrintEndingMessages(succededTests, failedTests, globalStopwatch.Elapsed.TotalSeconds);
        }

        private static MethodInfo[] GetAllTestMethodsFromTestingAssembly(Type testRunner)
            => Assembly
                .GetAssembly(testRunner)
                .GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(TestMethodAttribute), false).Length > 0)
                .ToArray();

        private static void MainLogic(ICollection<MethodInfo> allTestMethods,
            int succededTests,
            int testNumber,
            int failedTests)
        {
            foreach (var testMethod in allTestMethods)
            {
                var instance = _initializers.GetTestClassInstance(testMethod.DeclaringType);

                _initializers.ClassInitialize_IfExits(testMethod.DeclaringType, instance);
                _initializers.TestInitialize_IfExists(testMethod.DeclaringType, instance);

                try
                {
                    var stopwatch = CoreProjector.ProjectTest(() =>
                    {
                        testMethod.Invoke(instance, new object[0]);
                    }, 5000);

                    _uiManager.PrintAssertSuccessfullMessage(testMethod.Name, testNumber, stopwatch.ElapsedMilliseconds);

                    succededTests++;
                }
                catch (Exception generalException)
                {
                    if (generalException?.InnerException is AssertFailedException assertFailedException)
                    {
                        _uiManager.PrintAssertFailedExceptionMessage(assertFailedException, testMethod.Name, testNumber);
                        failedTests++;
                    }
                    else
                    {
                        _uiManager.PrintGeneralExceptionMessage(generalException, testMethod.Name, testNumber);
                        failedTests++;
                    }
                }
                finally
                {
                    Console.WriteLine(new string('-', 100));
                }

                testNumber++;
            }
        }
    }
}

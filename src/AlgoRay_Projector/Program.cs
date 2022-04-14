using AlgoRay.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AlgoRay_Projector
{
    internal class Program
    {
        private static readonly TestInitilizers _initializers = new TestInitilizers();
        private static readonly UiManager _uiManager = new UiManager();
        private static int failedTests = 0;
        private static int succededTests = 0;

        static async Task Main(string[] args)
        {
            _uiManager.PrintStartingMessages();

            var globalStopwatch = new Stopwatch();
            globalStopwatch.Start();

            var allTestMethods = GetAllTestMethodsFromTestingAssembly(typeof(TestRunner));

            Console.WriteLine(new string('-', 100));

            await MainLogic(allTestMethods);

            Console.WriteLine();
            Console.WriteLine(new string('_', 100));

            globalStopwatch.Stop();

            _uiManager.PrintEndingMessages(succededTests, failedTests, globalStopwatch.Elapsed.TotalSeconds);
        }

        private static async Task MainLogic(ICollection<MethodInfo> allTestMethods)
        {
            int testNumber = 1;

            foreach (var testMethod in allTestMethods)
            {
                var instance = _initializers.GetTestClassInstance(testMethod.DeclaringType);

                _initializers.ClassInitialize_IfExits(testMethod.DeclaringType, instance);
                _initializers.TestInitialize_IfExists(testMethod.DeclaringType, instance);

                var projectorAttribute = testMethod.GetCustomAttribute<ProjectorTimeOutAttribute>();
                var testTimeoutTimeInMilliseconds = GetProjectorTimeout(projectorAttribute?.TimeoutTimeInMilliseconds);

                try
                {
                    var stopwatch = await CoreProjector.ProjectTest(() =>
                    {
                        testMethod.Invoke(instance, new object[0]);
                    },
                    testTimeoutTimeInMilliseconds);

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

        private static MethodInfo[] GetAllTestMethodsFromTestingAssembly(Type testRunner)
            => Assembly
                .GetAssembly(testRunner)
                .GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(TestMethodAttribute), false).Length > 0)
                .ToArray();

        private static int GetProjectorTimeout(int? timeoutInMilliseconds)
            => Settings.IsInProjectorTimeoutMode && timeoutInMilliseconds != null ?
            timeoutInMilliseconds.Value :
            Settings.DefaultTimeout;
    }
}

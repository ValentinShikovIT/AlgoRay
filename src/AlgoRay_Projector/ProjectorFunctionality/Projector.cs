using AlgoRay.UnitTests.Helpers;
using AlgoRay_Projector.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace AlgoRay_Projector.ProjectorFunctionality
{
    internal class Projector : IProjector
    {
        private readonly ICoreProjector coreProjector;
        private readonly IUiManager uiManager;
        private readonly ITestInitializer testInitializer;
        private readonly ISettings settings;

        private int succededTests = 0;
        private int failedTests = 0;

        public Projector(
            ICoreProjector coreProjector,
            IUiManager uiManager,
            ITestInitializer testInitializer,
            ISettings settings)
        {
            this.coreProjector = coreProjector;
            this.uiManager = uiManager;
            this.testInitializer = testInitializer;
            this.settings = settings;
        }

        public async Task<(int successTests, int failedTests)> MainLogic(ICollection<MethodInfo> allTestMethods)
        {
            int testNumber = 1;

            foreach (var testMethod in allTestMethods)
            {
                var instance = testInitializer.GetTestClassInstance(testMethod.DeclaringType);

                testInitializer.IfClassInitializeAttrExists_Initialize(testMethod.DeclaringType, instance);
                testInitializer.IfTestInitializeAttrExists_Initialize(testMethod.DeclaringType, instance);

                var projectorAttribute = testMethod.GetCustomAttribute<ProjectorTimeOutAttribute>();
                var testTimeoutTimeInMilliseconds = GetProjectorTimeout(projectorAttribute?.TimeoutTimeInMilliseconds);

                try
                {
                    var stopwatch = await coreProjector.ProjectTest(() =>
                    {
                        testMethod.Invoke(instance, new object[0]);
                    },
                    testTimeoutTimeInMilliseconds);

                    uiManager.PrintAssertSuccessfullMessage(testMethod.Name, testNumber, stopwatch.ElapsedMilliseconds);

                    succededTests++;
                }
                catch (Exception generalException)
                {
                    if (generalException?.InnerException is AssertFailedException assertFailedException)
                    {
                        uiManager.PrintAssertFailedExceptionMessage(assertFailedException, testMethod.Name, testNumber);
                        failedTests++;
                    }
                    else
                    {
                        uiManager.PrintGeneralExceptionMessage(generalException, testMethod.Name, testNumber);
                        failedTests++;
                    }
                }
                finally
                {
                    Console.WriteLine(new string('-', 100));
                }

                testNumber++;
            }

            return (succededTests, failedTests);
        }

        private int GetProjectorTimeout(int? timeoutInMilliseconds)
            => settings.IsInProjectorTimeoutMode && timeoutInMilliseconds != null ?
            timeoutInMilliseconds.Value :
            settings.DefaultTimeout;
    }
}

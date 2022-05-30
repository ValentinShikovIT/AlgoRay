using AlgoRay_Projector.Cores;
using AlgoRay_Projector.Interfaces;
using AlgoRay_Projector.ProjectorFunctionality;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace AlgoRay_Projector
{
    internal class Program
    {
        // TODO: Add DIContainer
        private static readonly ITestInitializer initializer = new TestInitializer();
        private static readonly IUiManager uiManager = new UiManager();
        private static readonly IStopwatch globalStopwatch = new GlobalStopwatch();
        private static readonly IProjector projector = new Projector(new CoreProjector(), uiManager, initializer, new Settings());

        private static ICollection<MethodInfo> allTestMethods;
        private static int failedTests = 0;
        private static int succededTests = 0;

        static async Task Main(string[] args)
        {
            BeforeMain();

            (succededTests, failedTests) = await projector.MainLogic(allTestMethods);

            AfterMain();
        }

        private static void BeforeMain()
        {
            uiManager.PrintStartingMessages();

            globalStopwatch.Start();

            allTestMethods = initializer.GetTestsFromAssembly(default);
        }

        private static void AfterMain()
        {
            globalStopwatch.Stop();

            uiManager.PrintEndingMessages(succededTests, failedTests, globalStopwatch.GetStopwatch().Elapsed.TotalSeconds);
        }
    }
}

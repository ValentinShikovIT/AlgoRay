using AlgoRay.GraphTheory_Traversal_ShortestPath;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups.Dummies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoRay.UnitTests.GraphTraversalShortestPathEtc
{
    [TestClass]
    public class GraphTraversalShortestPathEtcTests : TestBase
    {
        [TestMethod]
        public void ConnectedComponents_ShouldReturn_CorrectResult()
        {
            // Arrange
            var tests = new (IList<int>[] Graph, IList<int[]> Expected)[]
            {
                GraphTraversalShortestPathEtcDummies.ConnectedComponents.Test_1,
                GraphTraversalShortestPathEtcDummies.ConnectedComponents.Test_2
            };

            // Act
            foreach (var (Graph, Expected) in tests)
            {
                var testResult = TestRunner.RunTest(() =>
                {
                    return ConnectedComponents
                    .Run(Graph);
                },
                100);

                AssertTestResultFromTestRunningResponse(testResult, Expected, false, false);
            }
        }

        [TestMethod]
        public void TopologicalSortSourceRemoval_ShouldReturn_CorrectResult()
        {
            // Arrange
            var tests = new (IDictionary<string, IList<string>> Graph, IList<string> Expected, bool ExpectedSuccessful)[]
            {
                GraphTraversalShortestPathEtcDummies.TopologicalSortSourceRemoval.Test_1,
                GraphTraversalShortestPathEtcDummies.TopologicalSortSourceRemoval.Test_2,
                GraphTraversalShortestPathEtcDummies.TopologicalSortSourceRemoval.Test_3
            };

            // Act
            foreach (var (Graph, Expected, ExpectedSuccessful) in tests)
            {
                var testResult = TestRunner.RunTest(() =>
                {
                    return TopologicalSortSourceRemoval
                    .Run(Graph);
                },
                100);

                AssertTestResultFromTestRunningResponse(testResult, Expected, false, false, ExpectedSuccessful);
            }
        }
    }
}

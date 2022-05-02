using AlgoRay.GraphTheory_Traversal_ShortestPath.Exercises;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups.Dummies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoRay.UnitTests.GraphTraversalShortestPathEtc
{
    [TestClass]
    public class GraphTraversalShortestPathEtcExercisesTests : TestBase
    {
        [TestMethod]
        public void DistanceBetweenVertices_Should_ReturnCorrectValues()
        {
            // Arrange
            var tests = new (IDictionary<int, List<int>> Graph, (int from, int to)[] paths, (int from, int to, int distance)[] expected)[]
            {
                GraphTraversalShortestPathEtcDummies.DistanceBetweenVertices.Test_1,
                GraphTraversalShortestPathEtcDummies.DistanceBetweenVertices.Test_2,
                GraphTraversalShortestPathEtcDummies.DistanceBetweenVertices.Test_3
            };

            // Act
            foreach (var (Graph, Paths, Expected) in tests)
            {
                var testResult = TestRunner.RunTest(() =>
                {
                    return new DistanceBetweenVertices()
                    .Run(Graph, Paths);
                },
                100);

                AssertTestResultFromTestRunningResponse(testResult, Expected);
            }
        }
    }
}

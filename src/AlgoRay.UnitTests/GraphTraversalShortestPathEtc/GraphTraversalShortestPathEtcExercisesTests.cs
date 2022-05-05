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

        [TestMethod]
        public void CyclesInGraph_Should_DetectCyclesInDirectedGraph()
        {
            // Arrange
            var tests = new (IDictionary<string, List<string>> Graph, bool expected)[]
            {
                GraphTraversalShortestPathEtcDummies.CyclesInGraph.Test_1,
                GraphTraversalShortestPathEtcDummies.CyclesInGraph.Test_2,
                GraphTraversalShortestPathEtcDummies.CyclesInGraph.Test_3,
                GraphTraversalShortestPathEtcDummies.CyclesInGraph.Test_4
            };

            // Act
            foreach (var (Graph, Expected) in tests)
            {
                var testResult = TestRunner.RunTest(() =>
                {
                    return new CyclesInGraph()
                    .Run(Graph);
                },
                100);

                AssertTestResultFromTestRunningResponse(testResult, Expected);
            }
        }

        [TestMethod]
        public void Salaries_Should_ReturnTheCorrectCummulations()
        {
            // Arrange
            var tests = new (IList<int>[] Graph, int Expected)[]
            {
                GraphTraversalShortestPathEtcDummies.Salaries.Test_1,
                GraphTraversalShortestPathEtcDummies.Salaries.Test_2
            };

            // Act
            foreach (var (Graph, Expected) in tests)
            {
                var testResult = TestRunner.RunTest(() =>
                {
                    return new Salaries()
                    .Run(Graph);
                },
                100);

                AssertTestResultFromTestRunningResponse(testResult, Expected);
            }
        }

        [TestMethod]
        public void BreakCycles_Should_ReturnAVariationOfThePossibleEdgesToRemoveInOrderToAchieveAcyclicGraph()
        {
            // Arrange
            var tests = new (IList<(string fromNode, string toNode)> EdgesOfGraph, IList<(string fromNode, string toNode)> ExpectedEdgesToBeRemoved)[]
            {
                GraphTraversalShortestPathEtcDummies.BreakCycles.Test_1,
                GraphTraversalShortestPathEtcDummies.BreakCycles.Test_2,
            };

            // Act
            foreach (var (EdgesOfGraph, ExpectedEdgesToBeRemoved) in tests)
            {
                var testResult = TestRunner.RunTest(() =>
                {
                    return new BreakCycles()
                    .Run(EdgesOfGraph);
                },
                100);

                AssertTestResultFromTestRunningResponse(testResult, ExpectedEdgesToBeRemoved);
            }
        }

        [TestMethod]
        public void RoadConstruction_Should_ReturnAVariationOfThePossibleEdgesThatWillBreakTheConnectionBetweenTheBuildings()
        {
            // Arrange
            var tests = new (IList<(int building1, int buildimg2)> EdgesOfGraph, IList<(int building1, int building2)> ExpectedEdges)[]
            {
                GraphTraversalShortestPathEtcDummies.RoadConstruction.Test_1,
                GraphTraversalShortestPathEtcDummies.RoadConstruction.Test_2,
            };

            // Act
            foreach (var (EdgesOfGraph, ExpectedEdges) in tests)
            {
                var testResult = TestRunner.RunTest(() =>
                {
                    return new RoadConstruction()
                    .Run(EdgesOfGraph);
                },
                100);

                AssertTestResultFromTestRunningResponse(testResult, ExpectedEdges);
            }
        }
    }
}

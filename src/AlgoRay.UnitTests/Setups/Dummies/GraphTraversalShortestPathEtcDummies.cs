using AlgoRay.UnitTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.Setups.Dummies
{
    internal class GraphTraversalShortestPathEtcDummies
    {
        internal static class ConnectedComponents
        {
            internal static (IList<int>[] Graph, IList<int[]> Expected) Test_1 { get; } =
                (@"3 6
                3 4 5 6
                8
                0 1 5
                1 6
                1 3
                0 1 4

                2".Split(Environment.NewLine)
                .Select(nodeChildren => nodeChildren.SplitWihtoutEmptyEntries().Select(int.Parse).ToList())
                .ToArray(),
                @"6 4 5 1 3 0
                8 2
                7".Split(Environment.NewLine)
                .Select(components => components.SplitWihtoutEmptyEntries().Select(int.Parse).ToArray())
                .ToList());

            internal static (IList<int>[] Graph, IList<int[]> Expected) Test_2 { get; } =
                (new List<int>[0],
                new List<int[]>());
        }

        internal static class TopologicalSortSourceRemoval
        {
            internal static (IDictionary<string, IList<string>> Graph, IList<string> Expected, bool ExpectedSuccessful) Test_1 { get; } =
                (@"A -> B, C
                B -> D, E
                C -> F
                D -> C, F
                E -> D
                F -> ".Split(Environment.NewLine)
                .Select(nodesToChildren => nodesToChildren.TrimStart().SplitWihtoutEmptyEntries(" -> "))
                .ToDictionary(key => key[0], value => value.Length > 1 ? (IList<string>)value[1].SplitWihtoutEmptyEntries(", ")
                .ToList() : new List<string>()),
                "A, B, E, D, C, F"
                    .Split(", ")
                    .ToList(),
                true);

            internal static (IDictionary<string, IList<string>> Graph, IList<string> Expected, bool ExpectedSuccessful) Test_2 { get; } =
                (@"IDEs -> variables, loops
                variables -> conditionals, loops, bits
                conditionals -> loops
                loops -> bits
                bits -> ".Split(Environment.NewLine)
                .Select(nodesToChildren => nodesToChildren.TrimStart().SplitWihtoutEmptyEntries(" -> "))
                .ToDictionary(key => key[0], value => value.Length > 1 ? (IList<string>)value[1].SplitWihtoutEmptyEntries(", ")
                .ToList() : new List<string>()),
                "IDEs, variables, conditionals, loops, bits"
                    .Split(", ")
                    .ToList(),
                true);

            internal static (IDictionary<string, IList<string>> Graph, IList<string> Expected, bool ExpectedSuccessful) Test_3 { get; } =
                (@"A -> B
                B -> A".Split(Environment.NewLine)
                .Select(nodesToChildren => nodesToChildren.TrimStart().SplitWihtoutEmptyEntries(" -> "))
                .ToDictionary(key => key[0], value => value.Length > 1 ? (IList<string>)value[1].SplitWihtoutEmptyEntries(", ")
                .ToList() : new List<string>()),
                new List<string>(),
                false);
        }

        internal static class ShortestPath
        {
            internal static (IList<int>[] Graph, int Start, int End, IList<int> Expected) Test_1 { get; } =
                (ParseGraph(@"1 2
                    1 4
                    2 3
                    4 5
                    5 8
                    5 6
                    5 7
                    5 8
                    6 7
                    7 8"),
                Start: 1,
                End: 7,
                "1 4 5 7".Split().Select(int.Parse).ToList());

            internal static (IList<int>[] Graph, int Start, int End, IList<int> Expected) Test_2 { get; } =
                (ParseGraph(@"1 5
                    1 4
                    5 7
                    7 8
                    8 2
                    2 3
                    3 4
                    4 1
                    6 2
                    9 10
                    11 9"),
                Start: 6,
                End: 3,
                "6 2 3".Split().Select(int.Parse).ToList());

            private static IList<int>[] ParseGraph(string graphStr)
            {
                var edges =
                    graphStr.Split(Environment.NewLine);

                var graph = new List<int>[edges.Length + 1];

                for (int i = 0; i < graph.Length; i++)
                {
                    graph[i] = new List<int>();
                }

                foreach (var edge in edges)
                {
                    var nodeToChild = edge
                    .TrimStart()
                    .SplitWihtoutEmptyEntries()
                    .Select(int.Parse)
                    .ToArray();

                    var firstNode = nodeToChild[0];
                    var secondNode = nodeToChild[1];

                    graph[firstNode].Add(secondNode);
                    graph[secondNode].Add(firstNode);
                }

                return graph;
            }
        }

        internal static class DistanceBetweenVertices
        {
            internal static (IDictionary<int, List<int>> graph, (int from, int to)[] targetPaths, (int from, int to, int distance)[] expected) Test_1 { get; } =
                (ParseGraph(@"1:2
                   2:"),
                @"1-2
                  2-1"
                .Trim()
                .Split(Environment.NewLine)
                .Select(x =>
                {
                    var splittedInput = x.SplitWihtoutEmptyEntries("-").Select(int.Parse).ToArray();
                    return (splittedInput[0], splittedInput[1]);
                })
                .ToArray(),
                @"{1, 2} -> 1
                  {2, 1} -> -1"
                .Replace("{", string.Empty)
                .Replace("}", string.Empty)
                .Replace(" ", string.Empty)
                .Split(Environment.NewLine)
                .Select(x =>
                {
                    var splitted = x.SplitWihtoutEmptyEntries("->");
                    var path = splitted[0].SplitWihtoutEmptyEntries(",").Select(int.Parse).ToArray();
                    return (path[0], path[1], int.Parse(splitted[1]));
                })
                .ToArray()
                );

            internal static (IDictionary<int, List<int>> graph, (int from, int to)[] targetPaths, (int from, int to, int distance)[] expected) Test_2 { get; } =
                (ParseGraph(@"1:4
                2:4
                3:4 5
                4:6
                5:3 7 8
                6:
                7:8
                8:"),
                @"1-6
                  1-5
                  5-6
                  5-8"
                .Trim()
                .Split(Environment.NewLine)
                .Select(x =>
                {
                    var splittedInput = x.SplitWihtoutEmptyEntries("-").Select(int.Parse).ToArray();
                    return (splittedInput[0], splittedInput[1]);
                })
                .ToArray(),
                @"{1, 6} -> 2
                  {1, 5} -> -1
                  {5, 6} -> 3
                  {5, 8} -> 1"
                .Replace("{", string.Empty)
                .Replace("}", string.Empty)
                .Replace(" ", string.Empty)
                .Split(Environment.NewLine)
                .Select(x =>
                {
                    var splitted = x.SplitWihtoutEmptyEntries("->");
                    var path = splitted[0].SplitWihtoutEmptyEntries(",").Select(int.Parse).ToArray();
                    return (path[0], path[1], int.Parse(splitted[1]));
                })
                .ToArray()
                );

            internal static (IDictionary<int, List<int>> graph, (int from, int to)[] targetPaths, (int from, int to, int distance)[] expected) Test_3 { get; } =
                (ParseGraph(@"11:4
                4:12 1
                1:12 21 7
                7:21
                12:4 19
                19:1 21
                21:14 31
                14:14
                31:"),
                @"11-7
                11-21
                21-4
                19-14
                1-4
                1-11
                31-21
                11-14"
                .Trim()
                .Split(Environment.NewLine)
                .Select(x =>
                {
                    var splittedInput = x.SplitWihtoutEmptyEntries("-").Select(int.Parse).ToArray();
                    return (splittedInput[0], splittedInput[1]);
                })
                .ToArray(),
                @"{11, 7} -> 3
                  {11, 21} -> 3
                  {21, 4} -> -1
                  {19, 14} -> 2
                  {1, 4} -> 2
                  {1, 11} -> -1
                  {31, 21} -> -1
                  {11, 14} -> 4"
                .Replace("{", string.Empty)
                .Replace("}", string.Empty)
                .Replace(" ", string.Empty)
                .Split(Environment.NewLine)
                .Select(x =>
                {
                    var splitted = x.SplitWihtoutEmptyEntries("->");
                    var path = splitted[0].SplitWihtoutEmptyEntries(",").Select(int.Parse).ToArray();
                    return (path[0], path[1], int.Parse(splitted[1]));
                })
                .ToArray()
                );

            private static IDictionary<int, List<int>> ParseGraph(string input)
            {
                var elements = input
                    .Split(Environment.NewLine)
                    .Select(x => x.SplitWihtoutEmptyEntries(":"));

                var result = new Dictionary<int, List<int>>();
                foreach (var element in elements)
                {
                    var from = int.Parse(element[0].Trim());
                    var children = element.Length > 1 ? element.Skip(1)
                        .SelectMany(x => x.Split())
                        .Select(int.Parse) : 
                        Enumerable.Empty<int>();

                    if (result.ContainsKey(from))
                    {
                        result[from].AddRange(children);
                    }
                    else
                    {
                        result[from] = new List<int>(children);
                    }
                }

                return result;
            }
        }
    }
}

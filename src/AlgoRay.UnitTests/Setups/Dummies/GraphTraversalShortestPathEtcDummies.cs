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
                (@"9
                3 6
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
                ("0".Split(Environment.NewLine)
                .Select(nodeChildren => nodeChildren.SplitWihtoutEmptyEntries().Select(int.Parse).ToList())
                .ToArray(),
                "".Split(Environment.NewLine)
                .Select(components => components.SplitWihtoutEmptyEntries().Select(int.Parse).ToArray())
                .ToList());
        }

        internal class TopologicalSortSourceRemoval
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
                ""
                    .Split(", ")
                    .ToList(),
                false);
        }
    }
}

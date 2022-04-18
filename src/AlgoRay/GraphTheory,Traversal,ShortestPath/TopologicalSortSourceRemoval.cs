using AlgoRay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoRay.GraphTheory_Traversal_ShortestPath
{
    public class TopologicalSortSourceRemoval
    {
        private static IDictionary<string, IList<string>> _graph = new Dictionary<string, IList<string>>();
        private static readonly Dictionary<string, int> nodeParents = new Dictionary<string, int>();
        private static readonly List<string> outputResults = new List<string>();

        public static AlgorithmicResult<IList<string>> Run(IDictionary<string, IList<string>> graph)
        {
            _graph = graph;

            foreach (var node in _graph.Keys)
            {
                if (!nodeParents.ContainsKey(node))
                {
                    nodeParents[node] = 0;
                }

                foreach (var child in _graph[node])
                {
                    if (nodeParents.ContainsKey(child))
                    {
                        nodeParents[child]++;
                    }
                    else
                    {
                        nodeParents[child] = 1;
                    }
                }
            }

            while (nodeParents.Count > 0)
            {
                var nodeWithZeroParents = nodeParents.FirstOrDefault(x => x.Value == 0);

                if (nodeWithZeroParents.Equals(default(KeyValuePair<string, int>)))
                {
                    return new AlgorithmicResult<IList<string>>(new List<string>(), false);
                }

                foreach (var child in _graph[nodeWithZeroParents.Key])
                {
                    nodeParents[child]--;
                }

                outputResults.Add(nodeWithZeroParents.Key);
                nodeParents.Remove(nodeWithZeroParents.Key);
            }

            return new AlgorithmicResult<IList<string>>(outputResults, true);
        }
    }
}

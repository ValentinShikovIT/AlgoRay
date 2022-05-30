using AlgoRay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.GraphTheory_Traversal_ShortestPath.Exercises
{
    public class BreakCycles
    {
        private IDictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private IList<Edge> _edges = new List<Edge>();

        public AlgorithmicResult<IList<(string fromNode, string toNode)>> Run(IList<(string fromNode, string toNode)> edgesOfGraph)
        {
            try
            {
                return Logic(edgesOfGraph);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<IList<(string fromNode, string toNode)>>(default, ex.Message);
            }
        }

        public AlgorithmicResult<IList<(string fromNode, string toNode)>> Logic(IList<(string fromNode, string toNode)> EdgesOfGraph)
        {
            foreach (var edge in EdgesOfGraph)
            {
                if (!graph.ContainsKey(edge.fromNode))
                {
                    graph[edge.fromNode] = new List<string>();
                }

                if (!graph.ContainsKey(edge.toNode))
                {
                    graph[edge.toNode] = new List<string>();
                }

                graph[edge.fromNode].Add(edge.toNode);

                _edges.Add(new Edge() { from = edge.fromNode, to = edge.toNode });
            }

            _edges = _edges
                .OrderBy(e => e.from)
                .ThenBy(e => e.to)
                .ToList();

            var results = new List<(string, string)>();
            var removedCounter = 0;
            foreach (var edge in _edges)
            {
                var removed = graph[edge.from].Remove(edge.to) && graph[edge.to].Remove(edge.from);

                if (!removed)
                {
                    continue;
                }

                var CanBeRemoved = BFS(edge.from, edge.to);

                if (CanBeRemoved)
                {
                    removedCounter++;
                    results.Add((edge.from, edge.to));
                    continue;
                }

                graph[edge.from].Add(edge.to);
                graph[edge.to].Add(edge.from);
            }

            return new AlgorithmicResult<IList<(string, string)>>(results);
        }

        private bool BFS(string from, string to)
        {
            var visited = new HashSet<string>();
            var queue = new Queue<string>();

            queue.Enqueue(from);
            visited.Add(from);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in graph[node])
                {
                    if (child == to)
                    {
                        return true;
                    }

                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    queue.Enqueue(child);
                    visited.Add(child);
                }
            }

            return false;
        }

        private class Edge
        {
            public string from;
            public string to;

            public override string ToString()
            {
                return $"{from} - {to}";
            }
        }
    }
}

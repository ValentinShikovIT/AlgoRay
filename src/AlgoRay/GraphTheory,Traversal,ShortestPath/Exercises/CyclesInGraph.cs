using AlgoRay.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.GraphTheory_Traversal_ShortestPath.Exercises
{
    public class CyclesInGraph
    {
        private IDictionary<string, List<string>> _graph = new Dictionary<string, List<string>>();
        private readonly HashSet<string> visited = new HashSet<string>();
        private HashSet<string> cycles = new HashSet<string>();

        public AlgorithmicResult<bool> Run(IDictionary<string, List<string>> graph)
        {
            this._graph = graph;

            var isAcyclic = BFS(graph.First().Key);

            return new AlgorithmicResult<bool>(!isAcyclic, true);
        }

        private bool BFS(string key)
        {
            var queue = new Queue<string>();
            cycles = new HashSet<string>();

            queue.Enqueue(key);
            visited.Add(key);
            cycles.Add(key);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in _graph[node])
                {
                    if (cycles.Contains(child))
                    {
                        return true;
                    }

                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                        cycles.Add(child);
                    }
                }
            }

            return false;
        }
    }
}

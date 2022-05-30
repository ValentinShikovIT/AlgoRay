using AlgoRay.Helpers;
using System;
using System.Collections.Generic;

namespace AlgoRay.GraphTheory_Traversal_ShortestPath.Exercises
{
    public class DistanceBetweenVertices
    {
        private IDictionary<int, List<int>> _graph = new Dictionary<int, List<int>>();
        private HashSet<int> visited = new HashSet<int>();
        private List<(int, int, int)> result = new List<(int, int, int)>();

        public AlgorithmicResult<IList<(int from, int to, int distance)>> Run(IDictionary<int, List<int>> graph, (int from, int to)[] targetPaths)
        {
            try
            {
                return Logic(graph, targetPaths);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<IList<(int from, int to, int distance)>>(default, ex.Message);
            }
        }

        public AlgorithmicResult<IList<(int from, int to, int distance)>> Logic(IDictionary<int, List<int>> graph, (int from, int to)[] targetPaths)
        {
            _graph = graph;

            CalculatePaths(targetPaths);

            return new AlgorithmicResult<IList<(int from, int to, int distance)>>(result);
        }

        private void CalculatePaths((int from, int to)[] paths)
        {
            foreach (var path in paths)
            {
                FindShortestPath(path.from, path.to);
            }
        }

        private void FindShortestPath(int start, int end)
        {
            var queue = new Queue<int>();
            visited.Clear();
            var parent = new Dictionary<int, int>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in _graph[node])
                {
                    if (child == end)
                    {
                        parent[child] = node;
                        var res = AddResult(parent, end);
                        result.Add((start, end, res));
                        return;
                    }

                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                        parent[child] = node;
                    }
                }
            }

            result.Add((start, end, -1));
        }

        private int AddResult(IDictionary<int, int> parent, int start)
        {
            var index = start;
            var counter = 0;

            while (parent.ContainsKey(index))
            {
                index = parent[index];
                counter++;
            }

            return counter;
        }
    }
}

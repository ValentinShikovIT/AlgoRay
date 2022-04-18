using AlgoRay.Helpers;
using System;
using System.Collections.Generic;

namespace AlgoRay.GraphTheory_Traversal_ShortestPath
{
    public class ShortestPath
    {
        private static IList<int>[] _graph;
        private static bool[] visited;
        private static int[] parent;

        private static IList<int> shortestPath;

        public static AlgorithmicResult<IList<int>> Run(IList<int>[] graph, int start, int end)
        {
            _graph = graph;
            visited = new bool[graph.Length + 1];
            parent = new int[graph.Length + 1];
            Array.Fill(parent, -1);

            FindShortestPath(start, end);

            return new AlgorithmicResult<IList<int>>(shortestPath, true);
        }

        private static void FindShortestPath(int node, int searched)
        {
            var queue = new Queue<int>();

            queue.Enqueue(node);
            visited[node] = true;

            while (queue.Count > 0)
            {
                node = queue.Dequeue();

                foreach (var child in _graph[node])
                {
                    if (child == searched)
                    {
                        parent[child] = node;
                        var path = GetPath(parent, child);

                        shortestPath = new List<int>(path);
                        return;
                    }

                    if (!visited[child])
                    {
                        parent[child] = node;
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        private static Stack<int> GetPath(int[] parent, int start)
        {
            var list = new Stack<int>();

            int index = start;
            while (index != -1)
            {
                list.Push(index);
                index = parent[index];
            }

            return list;
        }
    }
}

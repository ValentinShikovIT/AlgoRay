using AlgoRay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.GraphTheory_Traversal_ShortestPath.Exercises
{
    public class RoadConstruction
    {
        private IList<int>[] graph;
        private readonly List<Edge> edges = new List<Edge>();
        private bool[] visited;

        public AlgorithmicResult<IList<(int building1, int building2)>> Run(IList<(int building1, int building2)> buildingConnections)
        {
            graph = new List<int>[buildingConnections.Max(x => Math.Max(x.building1, x.building2)) + 1];

            foreach (var buildingConnection in buildingConnections)
            {
                if(graph[buildingConnection.building1] == null)
                {
                    graph[buildingConnection.building1] = new List<int>();
                }

                if(graph[buildingConnection.building2] == null)
                {
                    graph[buildingConnection.building2] = new List<int>();
                }

                graph[buildingConnection.building1].Add(buildingConnection.building2);
                graph[buildingConnection.building2].Add(buildingConnection.building1);

                edges.Add(new Edge() { from = buildingConnection.building1, to = buildingConnection.building2 });
                edges.Add(new Edge() { from = buildingConnection.building2, to = buildingConnection.building1 });
            }

            visited = new bool[graph.Length];

            var results= new List<(int building1, int building2)>();
            foreach (var edge in edges)
            {
                var alreadyRemoved = graph[edge.from].Remove(edge.to) && graph[edge.to].Remove(edge.from);

                if (!alreadyRemoved)
                {
                    continue;
                }

                var isImportant = DFS(edge.from, edge.to);

                if (isImportant)
                {
                    var first = Math.Min(edge.from, edge.to);
                    var second = Math.Max(edge.from, edge.to);

                    results.Add((first, second));
                    continue;
                }

                graph[edge.from].Add(edge.to);
                graph[edge.to].Add(edge.from);
            }

            return new AlgorithmicResult<IList<(int building1, int building2)>>(results, true);
        }

        private bool DFS(int from, int to)
        {
            var queue = new Queue<int>();
            Array.Fill(visited, false);

            queue.Enqueue(from);
            visited[from] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in graph[node])
                {
                    if (child == to && !visited[child])
                    {
                        return false;
                    }

                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }

            return true;
        }

        private class Edge
        {
            public int from;
            public int to;
        }
    }
}

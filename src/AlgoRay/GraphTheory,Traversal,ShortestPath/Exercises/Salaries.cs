using AlgoRay.Helpers;
using System.Collections.Generic;

namespace AlgoRay.GraphTheory_Traversal_ShortestPath.Exercises
{
    public class Salaries
    {
        private IList<int>[] _graph;
        private readonly IDictionary<int, int> nodeWithPoints = new Dictionary<int, int>();

        public AlgorithmicResult<int> Run(IList<int>[] graph)
        {
            _graph = graph;

            var result = 0;
            for (int i = 0; i < graph.Length; i++)
            {
                if (nodeWithPoints.ContainsKey(i))
                {
                    result += nodeWithPoints[i];
                    continue;
                }

                result += DFS(i);
            }

            return new AlgorithmicResult<int>(result, true);
        }

        private int DFS(int node)
        {
            if (_graph[node].Count == 0)
            {
                return 1;
            }

            var points = 0;
            foreach (var child in _graph[node])
            {
                if (nodeWithPoints.ContainsKey(child))
                {
                    points += nodeWithPoints[child];
                    continue;
                }

                points += DFS(child);
            }

            return points;
        }
    }
}

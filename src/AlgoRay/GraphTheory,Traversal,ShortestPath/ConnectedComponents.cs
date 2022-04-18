using AlgoRay.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.GraphTheory_Traversal_ShortestPath
{
    public class ConnectedComponents
    {
        private IList<int>[] _graph;
        private bool[] visited;
        private List<int> result;

        private readonly IList<int[]> outputResult = new List<int[]>();

        public AlgorithmicResult<IList<int[]>> Run(IList<int>[] graph)
        {
            _graph = graph;
            visited = new bool[graph.Length];

            for (int i = 0; i < _graph.Length; i++)
            {
                result = new List<int>();
                BFS(i);
                if (result.Count > 0)
                {
                    outputResult.Add(result.ToArray());
                }
            }

            return new AlgorithmicResult<IList<int[]>>(outputResult, true);
        }

        private void BFS(int nodeNumber)
        {
            var stack = new Stack<int>();
            var queue = new Queue<int>();

            if (visited[nodeNumber] == true)
            {
                return;
            }

            stack.Push(nodeNumber);
            visited[nodeNumber] = true;

            while (stack.Count > 0)
            {

                var node = stack.Peek();

                if (_graph[node].All(x => visited[x]) || _graph[node].Count == 0)
                {
                    result.Add(node);
                    stack.Pop();
                }

                foreach (var child in _graph[node])
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        stack.Push(child);
                        break;
                    }
                }
            }
        }
    }
}

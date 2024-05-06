using System.Text;
using Dijkstra.src.Domain.Entities;
using Dijkstra.src.Domain.Interfaces;

namespace Dijkstra.src.Application
{
    public class AlgorithmDijkstra : IAlgorithmDistances
    {
        private int[] distances;
        private bool[] visited;
        private string[] paths;
        private string[] nodes;
        private ShortestPathData pathData;
        int numberNodes;
        private IGraph graph;

        public AlgorithmDijkstra(IGraph graph)
        {
            numberNodes = graph.NodesCount();
            this.graph = graph;
            distances = new int[numberNodes];
            visited = new bool[numberNodes];
            paths = new string[numberNodes];
            pathData = new ShortestPathData(new List<string>(), 0);
            nodes = graph.GetNodes();

        }
        public ShortestPathData ShortestPath(string fromNodeName, string toNodeName)
        {
            ValidateNodesInGraph(fromNodeName, toNodeName);
            InitializePathDataFromNode(fromNodeName);

            ShortestPathFromNode(fromNodeName);

            if (!HasReachedToNode(toNodeName))
            {
                pathData.SetDistance(-1);
                return pathData;
            }

            return ShortestPathToNone(toNodeName);
        }

        private void ValidateNodesInGraph(string fromNodeName, string toNodeName)
        {
            if (!graph.ExistNode(fromNodeName))
                throw new Exception($"The Node {fromNodeName} is not part of the graph");

            if (!graph.ExistNode(toNodeName))
                throw new Exception($"The Node {toNodeName} is not part of the graph");
        }

        private void InitializePathDataFromNode(string fromNodeName)
        {
            for (int i = 0; i < numberNodes; i++)
            {
                distances[i] = int.MaxValue;
                visited[i] = false;

                distances[GetIndex(fromNodeName)] = 0;
                paths[GetIndex(fromNodeName)] = fromNodeName;
            }
        }

        private ShortestPathData ShortestPathToNone(string toNodeName)
        {
            pathData.NodeNames = paths[GetIndex(toNodeName)].Split(",").ToList();
            pathData.SetDistance(distances[GetIndex(toNodeName)]);

            return pathData;
        }

        private bool HasReachedToNode(string toNodeName)
        {
            return distances[GetIndex(toNodeName)] != int.MaxValue;
        }

        private void ShortestPathFromNode(string node)
        {

            int firstNodeIndex = GetIndex(node);

            if (visited[firstNodeIndex] == true)
                return;

            if (!ContainsNeighbours(node))
                return;

            CalculateDistancesToNeighbours(node);
            ShortestPathFromNode(GetClosestNeighbour(node));
        }

        private bool ContainsNeighbours(string node)
        {
            var neighbors = graph.GetNeighbours(node);

            if (neighbors.Length == 0)
            {
                visited[GetIndex(node)] = true;
                return false;
            }

            return true;
        }

        private void CalculateDistancesToNeighbours(string firstNode)
        {
            StringBuilder shortespath = new StringBuilder();


            var neighbors = graph.GetNeighbours(firstNode);
            int firstNodeIndex = GetIndex(firstNode);

            foreach (var neighbor in neighbors)
            {

                var secondNodeIndex = GetIndex(neighbor);
                int weight = graph.GetEdgeWeight(firstNode, neighbor);

                if (!visited[secondNodeIndex] && distances[firstNodeIndex] != int.MaxValue && distances[firstNodeIndex] + weight < distances[secondNodeIndex])
                {
                    distances[secondNodeIndex] = distances[firstNodeIndex] + weight;

                    shortespath.Clear();
                    shortespath.Append(paths[firstNodeIndex] + ",");
                    shortespath.Append(neighbor);

                    paths[secondNodeIndex] = shortespath.ToString();
                }
            }
            visited[firstNodeIndex] = true;
        }
        private int GetIndex(string node)
        {
            return Array.IndexOf(nodes, node);
        }
        private string GetClosestNeighbour(string node)
        {
            var neighbors = graph.GetNeighbours(node);
            if (neighbors == null)
                return "";

            var minNextPath = neighbors.Select((value) => new { value })
                    .MinBy(item => graph.GetEdgeWeight(node, item.value));

            if (minNextPath is null)
                return "";

            return minNextPath.value;
        }

    }
}
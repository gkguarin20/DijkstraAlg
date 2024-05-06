using Dijkstra.src.Domain.Entities;
using Dijkstra.src.Domain.Interfaces;

namespace Dijkstra.src.Domain.Entities
{
    public class Graph : IGraph
    {
        private readonly List<Node> nodes;
        private readonly List<Edge> edges;
        public Graph()
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
        }

        public void AddNode(string nodeName)
        {
            if (ExistNode(nodeName))
                throw new Exception($"Node {nodeName} has already been created");

            CreateNode(nodeName);
        }
        private void CreateNode(string nodeName)
        {
            Node node = new Node(nodeName);
            nodes.Add(node);
        }
        private Node? GetNode(string nodeName)
        {
            return nodes.Where(x => x.Name.Equals(nodeName)).FirstOrDefault();
        }
        public bool ExistNode(string nodeName)
        {
            return nodes.Where(x => x.Name.Equals(nodeName)).Any();
        }

        public void AddEdge(string fromNode, string toNode, int weight)
        {
            ValidateDataEdge(fromNode, toNode, weight);

            if (ExistEdge(fromNode, toNode))
                throw new Exception($"Edge {fromNode}-{toNode} has already been created");

            CreateEdge(fromNode, toNode, weight);
            CreateEdge(toNode, fromNode, weight);
        }
        public void AddDirectEdge(string fromNode, string toNode, int weight)
        {
            ValidateDataEdge(fromNode, toNode, weight);

            if (ExistDirectedEdge(fromNode, toNode))
                throw new Exception($"Edge {fromNode}-{toNode} has already been created");

            CreateEdge(fromNode, toNode, weight);
        }

        private void ValidateDataEdge(string fromNode, string toNode, int weight)
        {
            if (!ExistNode(fromNode))
                throw new Exception($"Node {fromNode} does not exist");

            if (!ExistNode(toNode))
                throw new Exception($"Node {toNode} does not exist");

            if (weight < 1)
                throw new Exception("weight should be higher that 1");
        }

        private bool ExistEdge(string fromNode, string toNode)
        {
            return ExistDirectedEdge(fromNode, toNode) && ExistDirectedEdge(toNode, fromNode);
        }

        private bool ExistDirectedEdge(string fromNode, string toNode)
        {
            return edges.Where(x => x.FromNode.Name.Equals(fromNode) && x.ToNode.Name.Equals(toNode)).Any();
        }

        private void CreateEdge(string fromNode, string toNode, int weight)
        {
            Edge edge = new Edge(GetNode(fromNode), GetNode(toNode), weight);
            edges.Add(edge);

        }

        public int NodesCount()
        {
            return nodes.Count;
        }

        public string[] GetNodes()
        {
            return nodes.Select(node => node.Name).ToArray();
        }

        public string[] GetNeighbours(string node)
        {
            return edges.Where(edge => edge.FromNode.Name.Equals(node)).Select(edge => edge.ToNode.Name).ToArray();
        }

        public int GetEdgeWeight(string fromNode, string toNode)
        {
            return edges.Where((edge) => edge.FromNode.Name.Equals(fromNode) && edge.ToNode.Name.Equals(toNode))
                .Select(edge => edge.Weight)
                .FirstOrDefault();
        }

    }
}



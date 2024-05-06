namespace Dijkstra.src.Domain.Entities
{
    public class Edge
    {
        public Node FromNode { get; set; }
        public Node ToNode { get; set; }
        public int Weight { get; set; }

        public Edge(Node fromNode, Node toNode, int weight)
        {
            FromNode = fromNode;
            ToNode = toNode;
            Weight = weight;
        }
    }
}
using Dijkstra.src.Domain.Entities;

namespace Dijkstra.src.Domain.Interfaces
{
    public interface IGraph
    {
        void AddNode(string node);
        void AddEdge(string fromNode, string toNode, int weight);
        int NodesCount();
        string[] GetNodes();

        bool ExistNode(string node);
        string[] GetNeighbours(string node);
        int GetEdgeWeight(string fromNode, string toNode);
    }
}
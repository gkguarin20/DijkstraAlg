using Dijkstra.src.Domain.Entities;

namespace Dijkstra.src.Domain.Interfaces
{
    public interface IAlgorithmDistances
    {
        ShortestPathData ShortestPath(string fromNodeName, string toNodeName);
    }
}
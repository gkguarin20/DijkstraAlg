using Dijkstra.src.Domain.Interfaces;

namespace Dijkstra.src.Domain.Entities
{
    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; }
        private int _distance;
        public int Distance { get { return _distance; } }
        public ShortestPathData(List<string> nodeNames, int distance)
        {
            NodeNames = nodeNames;
            _distance = distance;
        }

        public void SetDistance(int distance)
        {
            _distance = distance;
        }
    }
}
using Dijkstra.src.Domain.Interfaces;

namespace Dijkstra.src.Domain.Entities
{
    public class Node
    {
        private string _name;
        public string Name { get { return _name; } }
        public Node(string name)
        {
            this._name = name;
        }

        public void CreateNode(string nodeName)
        {
            this._name = nodeName;
        }
    }
}
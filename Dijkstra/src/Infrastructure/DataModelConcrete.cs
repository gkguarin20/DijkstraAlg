using Dijkstra.src.Domain.Entities;
using Dijkstra.src.Domain.Interfaces;

namespace Dijkstra.src.Infrastructure
{
    public class DataModelConcrete
    {
        private IGraph graph;

        public DataModelConcrete(IGraph graph)
        {
            this.graph = graph;

        }

        public static IGraph GraphTest()
        {
            var graph = new Graph();

            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");
            graph.AddNode("F");
            graph.AddNode("G");
            graph.AddNode("H");
            graph.AddNode("I");

            graph.AddEdge("A", "B", 4);
            graph.AddEdge("B", "F", 2);
            graph.AddEdge("F", "E", 3);
            graph.AddEdge("F", "G", 4);
            graph.AddEdge("F", "H", 6);
            graph.AddEdge("H", "G", 5);
            graph.AddEdge("G", "I", 5);
            graph.AddEdge("G", "D", 1);
            graph.AddEdge("E", "D", 4);
            graph.AddEdge("D", "C", 8);
            graph.AddDirectEdge("E", "B", 2);

            return graph;
            /*  graph.AddNode("A");
              graph.AddNode("B");
              graph.AddNode("C");
              graph.AddNode("D");
              graph.AddNode("E");
              graph.AddNode("F");
              graph.AddNode("G");
              graph.AddNode("H");

              graph.AddEdge("A", "B", 20);
              graph.AddDirectEdge("A", "G", 90);
              graph.AddEdge("A", "D", 80);
              graph.AddDirectEdge("B", "F", 10);
              graph.AddDirectEdge("F", "D", 40);
              graph.AddDirectEdge("F", "C", 10);
              graph.AddDirectEdge("C", "F", 50);
              graph.AddDirectEdge("C", "H", 20);
              graph.AddEdge("C", "D", 10);
              graph.AddDirectEdge("D", "G", 20);
              graph.AddDirectEdge("G", "A", 20);
              graph.AddDirectEdge("E", "G", 30);
              graph.AddDirectEdge("E", "B", 50);

              return graph;
              */


        }
    }
}
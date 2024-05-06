using Dijkstra.src.Domain.Entities;

namespace DijkstraAlg.Test
{
    public class GraphTest
    {
        [Fact]
        public void AddNode_WhenNodeDoesNotExist_ShouldAddNode()
        {
            var graph = new Graph();

            graph.AddNode("A");

            Assert.True(graph.ExistNode("A"));
        }

        [Fact]
        public void AddNode_WhenNodeAlreadyExists_ShouldThrowException()
        {
            var graph = new Graph();
            graph.AddNode("A");
            var exception = Assert.Throws<Exception>(() => graph.AddNode("A"));
            Assert.Equal("Node A has already been created", exception.Message);
        }

        [Fact]
        public void AddEdge_WhenNodesExistAndEdgeDoesNotExist_ShouldAddEdge()
        {
            var graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");

            graph.AddEdge("A", "B", 10);

            Assert.True(graph.GetEdgeWeight("A", "B") == 10);
        }

        [Fact]
        public void AddEdge_WhenEdgeAlreadyExists_ShouldThrowException()
        {
            var graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddEdge("A", "B", 10);


            var exception = Assert.Throws<Exception>(() => graph.AddEdge("A", "B", 20));
            Assert.Equal("Edge A-B has already been created", exception.Message);
        }
    }
}
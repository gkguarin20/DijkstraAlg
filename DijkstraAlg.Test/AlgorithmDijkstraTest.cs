using Dijkstra.src.Application;
using Dijkstra.src.Domain.Entities;

namespace DijkstraAlg.Test;

public class AlgorithmDijkstraTest
{

    [Fact]
    public void ShortestPath_WhenFromAndToNodesExist_ShouldReturnShortestPath()
    {

        var graph = new Graph();
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddEdge("A", "B", 10);
        graph.AddEdge("A", "C", 20);

        var algorithm = new AlgorithmDijkstra(graph);


        var result = algorithm.ShortestPath("A", "B");

        Assert.NotNull(result);
        Assert.Equal(new List<string> { "A", "B" }, result.NodeNames);
        Assert.Equal(10, result.Distance);
    }

    [Fact]
    public void ShortestPath_WhenFromNodeDoesNotExist_ShouldThrowException()
    {
        var graph = new Graph();
        var algorithm = new AlgorithmDijkstra(graph);

        var exception = Assert.Throws<Exception>(() => algorithm.ShortestPath("A", "B"));
        Assert.Equal("The Node A is not part of the graph", exception.Message);
    }




}
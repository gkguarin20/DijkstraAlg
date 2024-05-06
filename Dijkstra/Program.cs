// See https://aka.ms/new-console-template for more information

using Dijkstra.src.Application;
using Dijkstra.src.Domain.Entities;
using Dijkstra.src.Domain.Interfaces;
using Dijkstra.src.Infrastructure;
using System;
try
{
    Console.WriteLine("From Node: ");
    var fromNode = Console.ReadLine();

    while (string.IsNullOrEmpty(fromNode))
    {
        Console.WriteLine("Invalid input. Please enter a non-empty string for the from node:");
        fromNode = Console.ReadLine();
    }

    Console.WriteLine("To Node: ");
    var toNode = Console.ReadLine();


    while (string.IsNullOrEmpty(toNode))
    {
        Console.WriteLine("Invalid input. Please enter a non-empty string for the to node:");
        toNode = Console.ReadLine();
    }

    var graph = DataModelConcrete.GraphTest();



    var algorithm = new AlgorithmDijkstra(graph);

    var result = algorithm.ShortestPath(fromNode, toNode);
    var shortestPath = string.Join(", ", result.NodeNames);

    Console.WriteLine($"The shortest Path between Node {fromNode} and {toNode} is {shortestPath} with a distance of {result.Distance}");


}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}



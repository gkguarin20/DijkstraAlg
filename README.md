# Design Dijkstra Algorithm

## Overview
Code challenge for Designing a shortest path from one location to another location within connected nodes using Dijkstra Algorithm. 


## Technologies Implemented
### Console application .NET 7.0.


## Requirements
1. Not all nodes are connected bidirectional, for e.g., from B we can’t navigate to E but from E we can go to B
2. Develop a console app using C#
3. Create a data model for the above graph
4. Create function which accepts three parameters from Node, to Node and List of Nodes that is the source.
a. E.g. ShortestPath(string fromNodeName,string toNodeName, List<Nodes> graphNode){ your code
here}
b. The function should return a model
i. Class ShortestPathData
{
List<string> NodeNames{get;set;}
Int Distance {get;}
}
5. The above function should give me a List of node name in order
a. E.g., fromNodeName = “A”, toNodeName =” D”, I expect a list A, B, F, G, D
b. Also need to return me the distance in total
6. Write the result in the console with comma separation

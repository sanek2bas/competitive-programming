using System.Reflection.Metadata;
using Top.Interview._150.Common;

namespace Top.Interview._150.Graph_General;

public class CloneGraph
{
    
    /// <summary>
    /// # 133
    /// https://leetcode.com/problems/clone-graph/description/
    /// Given a reference of a node in a connected undirected graph.
    /// Return a deep copy (clone) of the graph.
    /// Each node in the graph contains a value (int) and 
    /// a list (List[Node]) of its neighbors.
    /// Test case format:
    /// For simplicity, each node's value is the same as the node's index (1-indexed). 
    /// For example, the first node with val == 1, the second node with val == 2, 
    /// and so on. The graph is represented in the test case using an adjacency list.
    /// An adjacency list is a collection of unordered lists used to represent 
    /// a finite graph. Each list describes the set of neighbors of a node in the graph.
    /// The given node will always be the first node with val = 1. 
    /// You must return the copy of the given node as a reference to the cloned graph.
    /// </summary>
    public Node Execute(Node node)
    {
        if (node == null)
            return node;

        var clones = new Dictionary<Node, Node>();
        var queue = new Queue<Node>();
        
        var clone = new Node(node.Value);
        clones.Add(node, clone);
        queue.Enqueue(node);

        while(queue.Count > 0)
        {
            var original = queue.Dequeue();
            foreach (var originalNeighbor in original.Neighbors)
            {
                if (!clones.ContainsKey(originalNeighbor))
                {
                    clones.Add(originalNeighbor, new Node(originalNeighbor.Value));
                    queue.Enqueue(originalNeighbor);
                }
                clones[original].Neighbors.Add(clones[originalNeighbor]);
            }
        }
        return clones[node];
    }    
}
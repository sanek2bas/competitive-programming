using System;
using System.ComponentModel;

namespace Infrastructure;

public sealed class Node
{
    public int Value { get; set; }

    public IList<Node> Neighbors { get; init; }

    public Node() : this(0)
    {
    }

    public Node(int value)
    {
        Value = value;
        Neighbors = new List<Node>();
    }

    public static Node? Map(IList<int[]> neighbors)
    {
        var nodesDic = new Dictionary<int, Node>();
        for (int i = 1; i <= neighbors.Count; i++)
        {
            var node = GetNode(nodesDic, i);
            for (int j = 0; j < neighbors[i].Length; j++)
            {
                var neighbor = GetNode(nodesDic, neighbors[i][j]);
                node.Neighbors.Add(neighbor);
            }         
        }

        nodesDic.TryGetValue(1, out Node? firstNode);
        return firstNode;
    }

    private static Node GetNode(Dictionary<int, Node> nodesDic, int key)
    {
        if (!nodesDic.ContainsKey(key))
            nodesDic.Add(key, new Node(key));
        return nodesDic[key];
    }
}

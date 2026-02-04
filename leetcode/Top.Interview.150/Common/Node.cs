using System.Runtime.InteropServices;

namespace Top.Interview._150.Common;

public class Node
{
    public int Value { get; }

    public IList<Node> Neighbors { get; }

    public Node(int val = 0) 
    {
        Value = val;
        Neighbors = new List<Node>();
    }

    public static Node Create(int[][] nodes)
    {
        var created = new Dictionary<int, Node>();
        for (int i = 0; i < nodes.Length; i++)
        {
            Node node = GetOrAdd(created, i+1);
            for (int j = 0; j < nodes[i].Length; j++)
            {
                var neighbor = GetOrAdd(created, nodes[i][j]);
                node.Neighbors.Add(neighbor);
            }
        }
        _ = created.TryGetValue(1, out Node firstNode);
        return firstNode;
    }

    private static Node GetOrAdd(Dictionary<int, Node> dic, int index)
    {
        Node node;
        if (!dic.TryGetValue(index, out node))
        {
            node = new Node(index);
            dic.Add(index, node);
        }
        return node;
    }
}
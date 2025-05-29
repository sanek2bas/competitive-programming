using System;

namespace Infrastructure;

public sealed class TreeListNode
{
    public int Value { get; init; }

    public TreeListNode? Next { get; set; }

    public TreeListNode? Left { get; set; }

    public TreeListNode? Right { get; set; }

    public TreeListNode(int value = -1)
    {
        Value = value;
    }

    public static TreeListNode Map(params int?[] values)
    {
        if (values == null ||
            values.Length == 0 ||
            values[0] == null)
            return null;

        var rootNode = new TreeListNode(values[0].Value);

        var queue = new Queue<TreeListNode>();
        queue.Enqueue(rootNode);
        int i = 1;
        while (i < values.Length)
        {
            var value = values[i];
            var node = queue.Dequeue();
            if (value != null)
            {
                var leftNode = new TreeListNode(value.Value);
                queue.Enqueue(leftNode);
                node.Left = leftNode;
            }
            i++;
            if (i >= values.Length)
                break;
            value = values[i];
            if (value != null)
            {
                var rightNode = new TreeListNode(value.Value);
                queue.Enqueue(rightNode);
                node.Right = rightNode;
            }
            i++;
        }

        return rootNode;
    }
}

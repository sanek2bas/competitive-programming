namespace Top.Interview._150.Common;

public class TreeListNode<T>
{
    public T Value { get; init; }

    public TreeListNode<T>? Next { get; set; }

    public TreeListNode<T>? Left { get; set; }

    public TreeListNode<T>? Right { get; set; }

    private TreeListNode(T value)
    {
        Value = value;
    }

    public static TreeListNode<T>? Create(params T[] values)
    {
        if (values == null ||
            values.Length == 0 ||
            values[0] == null)
            return null;

        var rootNode = new TreeListNode<T>(values[0]);

        var queue = new Queue<TreeListNode<T>>();
        queue.Enqueue(rootNode);
        int i = 1;
        while (i < values.Length)
        {
            var value = values[i];
            var node = queue.Dequeue();
            if (value != null)
            {
                var leftNode = new TreeListNode<T>(value);
                queue.Enqueue(leftNode);
                node.Left = leftNode;
            }
            i++;
            if (i >= values.Length)
                break;
            value = values[i];
            if (value != null)
            {
                var rightNode = new TreeListNode<T>(value);
                queue.Enqueue(rightNode);
                node.Right = rightNode;
            }
            i++;
        }

        return rootNode;
    }
}

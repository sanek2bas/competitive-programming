namespace Top.Interview._150.Common;

public class ListNode<T>
{
    public T Value { get; init; }

    public ListNode<T>? Next { get; set; }

    public ListNode(T value)
    {
        Value = value;
    }

    public static ListNode<T>? Create(params T[] values)
    {
        var startNode = new ListNode<T>(default);
        var nextNode = startNode;
        foreach (T value in values)
        {
            nextNode.Next = new ListNode<T>(value);
            nextNode = nextNode.Next;
        }
        return startNode.Next;
    }

    public static ListNode<T>? CreateWithCycle(T[] numbers, int position)
    {
        var root = Create(numbers);
        if (root == null)
            return null;

        var lastNode = root;
        while (lastNode?.Next != null)
            lastNode = lastNode.Next;
        if (lastNode == null)
            return null;

        if (position >= 0)
        {
            ListNode<T>? posNode = root;
            for (int i = 1; i <= position; i++)
                posNode = posNode?.Next;
            lastNode.Next = posNode;
        }

        return root;
    }

    public static T[] ConvertToArray(ListNode<T> root)
    {
        var node = root;
        var values = new List<T>();
        while (node != null)
        {
            values.Add(node.Value);
            node = node.Next;
        }
        return [.. values];
    }
}
namespace Top.Interview._150.Common;

public sealed class ListNode(int value = -1)
{
    public int Value { get; init; } = value;
    public ListNode? Next { get; set; }

    public static ListNode? Map(params int[] numbers)
    {
        var startNode = new ListNode();
        var nextNode = startNode;
        foreach (int number in numbers)
        {
            nextNode.Next = new ListNode(number);
            nextNode = nextNode.Next;
        }
        return startNode.Next;
    }

    public static ListNode? Map(int[] numbers, int pos)
    {
        var root = Map(numbers);
        var lastNode = root;
        while (lastNode?.Next != null)
            lastNode = lastNode.Next;

        if (pos >= 0)
        {
            ListNode? posNode = root;
            for (int i = 1; i <= pos; i++)
                posNode = posNode?.Next;
            lastNode.Next = posNode;
        }

        return root;
    }

    public static int[] ToArray(ListNode root)
    {
        var node = root;
        var numbers = new List<int>();
        while (node != null)
        {
            numbers.Add(node.Value);
            node = node.Next;
        }
        return [.. numbers];
    }
}
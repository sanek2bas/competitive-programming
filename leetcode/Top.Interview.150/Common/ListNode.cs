namespace Top.Interview._150.Common;

public class ListNode
{
    public int Value { get; init; }

    public ListNode Next { get; set; }

    private ListNode(int value)
    {
        Value = value;
    }

    public int[] ToArray()
    {
        var node = this;
        var values = new List<int>();
        while (node != null)
        {
            values.Add(node.Value);
            node = node.Next;
        }
        return [.. values];
    }

    public static ListNode Create(params int[] numbers)
    {
        var startNode = new ListNode(default);
        var nextNode = startNode;
        foreach (int number in numbers)
        {
            nextNode.Next = new ListNode(number);
            nextNode = nextNode.Next;
        }
        return startNode.Next;
    }

    public static ListNode CreateWithCycle(int[] numbers, int position)
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
            ListNode posNode = root;
            for (int i = 1; i <= position; i++)
                posNode = posNode?.Next;
            lastNode.Next = posNode;
        }

        return root;
    }
}
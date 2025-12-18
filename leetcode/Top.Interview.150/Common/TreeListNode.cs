namespace Top.Interview._150.Common;

public class TreeListNode
{
    public int Value { get; init; }

    public TreeListNode Next { get; set; }

    public TreeListNode Left { get; set; }

    public TreeListNode Right { get; set; }

    private TreeListNode(int value)
    {
        Value = value;
    }

    public static TreeListNode Create(params int?[] numbers)
    {
        if (numbers == null 
            || numbers.Length == 0 
            || numbers[0] == null)
            return null;

        var rootNode = new TreeListNode(numbers[0].Value);

        var queue = new Queue<TreeListNode>();
        queue.Enqueue(rootNode);
        int i = 1;
        while (i < numbers.Length)
        {
            var number = numbers[i];
            var node = queue.Dequeue();
            if (number != null)
            {
                var leftNode = new TreeListNode(number.Value);
                queue.Enqueue(leftNode);
                node.Left = leftNode;
            }
            i++;
            if (i >= numbers.Length)
                break;
            number = numbers[i];
            if (number != null)
            {
                var rightNode = new TreeListNode(number.Value);
                queue.Enqueue(rightNode);
                node.Right = rightNode;
            }
            i++;
        }

        return rootNode;
    }
}

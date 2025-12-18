namespace Top.Interview._150.Common;

public class TreeNode<T>
{
    public T Value { get; init; }

    public TreeNode<T?> Left { get; set; }

    public TreeNode<T?> Right { get; set; }

    private TreeNode(T value)
    {
        Value = value;
    }

    public static TreeNode<T?>? Create(params T?[] values)
    {
        if (values == null
            || values.Length == 0
            || values[0] == null)
            return null;

        var rootNode = new TreeNode<T?>(values[0]);

        var queue = new Queue<TreeNode<T?>>();
        queue.Enqueue(rootNode);
        int i = 1;

        while (i < values.Length)
        {
            var value = values[i];
            var node = queue.Dequeue();
            if (value != null)
            {
                var leftNode = new TreeNode<T?>(value);
                queue.Enqueue(leftNode);
                node.Left = leftNode;
            }
            i++;
            if (i >= values.Length)
                break;
            value = values[i];
            if (value != null)
            {
                var rightNode = new TreeNode<T?>(value);
                queue.Enqueue(rightNode);
                node.Right = rightNode;
            }
            i++;
        }
        return rootNode;
    }

    public static T?[] ToArray(TreeNode<T?> root)
    {
        var answer = new List<T?>();
        if (root != null)
        {
            answer.Add(root.Value);
            var queue = new Queue<TreeNode<T?>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Left == null && node.Right == null)
                    continue;
                if (node.Left != null)
                {
                    answer.Add(node.Left.Value);
                    queue.Enqueue(node.Left);
                }
                else
                {
                    answer.Add(default);
                }
                if (node.Right != null)
                {
                    answer.Add(node.Right.Value);
                    queue.Enqueue(node.Right);
                }
                else
                {
                    answer.Add(default);
                }
            }
        }
        return answer.ToArray();
    }
}
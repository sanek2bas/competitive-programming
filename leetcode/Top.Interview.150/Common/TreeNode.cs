using System.Diagnostics;

namespace Top.Interview._150.Common;

public class TreeNode
{
    public int Value { get; init; }

    public TreeNode Left { get; set; }

    public TreeNode Right { get; set; }

    private TreeNode(int value)
    {
        Value = value;
    }

    public static TreeNode Create(params int?[] numbers)
    {
        if (numbers == null
            || numbers.Length == 0
            || numbers[0] == null)
            return null;

        var rootNode = new TreeNode(numbers[0].Value);

        var queue = new Queue<TreeNode>();
        queue.Enqueue(rootNode);
        int i = 1;

        while (i < numbers.Length)
        {
            var number = numbers[i];
            var node = queue.Dequeue();
            if (number != null)
            {
                var leftNode = new TreeNode(number.Value);
                queue.Enqueue(leftNode);
                node.Left = leftNode;
            }
            i++;
            if (i >= numbers.Length)
                break;
            number = numbers[i];
            if (number != null)
            {
                var rightNode = new TreeNode(number.Value);
                queue.Enqueue(rightNode);
                node.Right = rightNode;
            }
            i++;
        }
        return rootNode;
    }

    public static int?[] ToArray(TreeNode root)
    {
        var answer = new List<int?>();
        if (root != null)
        {
            answer.Add(root.Value);
            var queue = new Queue<TreeNode>();
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
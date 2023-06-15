namespace Interview.Infrastructure
{
    public class TreeNode
    {
        public int Value { get; init; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
        }

        public static TreeNode? CreateTreeNode(params int?[] values)
        {
            if (values == null ||
                values.Length == 0 ||
                values[0] == null)
                return null;
            
            var rootNode = new TreeNode(values[0].Value);
            
            var queue = new Queue<TreeNode>();
            queue.Enqueue(rootNode);
            int i = 1;
            while (i < values.Length)
            {
                var value = values[i];
                var node = queue.Dequeue();
                if(value != null)
                {
                    var leftNode = new TreeNode(value.Value);
                    queue.Enqueue(leftNode);
                    node.Left = leftNode;
                }
                i++;
                if (i >= values.Length)
                    break;
                value = values[i];
                if(value != null)
                {
                    var rightNode = new TreeNode(value.Value);
                    queue.Enqueue(rightNode);
                    node.Right = rightNode;
                }
                i++;
            }  

            return rootNode;
        }
    }
}

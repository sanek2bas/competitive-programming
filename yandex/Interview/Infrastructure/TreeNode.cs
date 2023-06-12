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

        public static TreeNode CreateTreeNode(int rootValue, int? leftChildValue, int? rightChildValue)
        {
            var rootNode = new TreeNode(rootValue);
            if (leftChildValue != null)
                rootNode.Left = new TreeNode(leftChildValue.Value);
            if(rightChildValue != null)
                rootNode.Right = new TreeNode(rightChildValue.Value);
            return rootNode;
        }
    }
}

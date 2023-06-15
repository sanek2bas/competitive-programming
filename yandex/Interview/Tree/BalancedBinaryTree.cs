using Interview.Infrastructure;

namespace Interview.Tree
{
    public static class BalancedBinaryTree
    {
        public static bool Execute(TreeNode root)
        {
            if (root == null)
                return true;
            return Math.Abs(maxDepth(root.Left) - maxDepth(root.Right)) <= 1
                && Execute(root.Left)
                && Execute(root.Right);
        }

        private static int maxDepth(TreeNode node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(maxDepth(node.Left), maxDepth(node.Right));
        }

        public static IEnumerable<(TreeNode root, bool answer)> GetTests()
        {
            yield return (TreeNode.CreateTreeNode(3, 9, 20, null, null, 15, 7), true);
            yield return (TreeNode.CreateTreeNode(1, 2, 2, 3, 3, null, null, 4, 4), false);
            yield return (TreeNode.CreateTreeNode(), true);
            yield return (TreeNode.CreateTreeNode(null), true);
            yield return (TreeNode.CreateTreeNode(0), true);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}

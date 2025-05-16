using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral
{
    public static class InvertBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, return its maximum depth.
        /// A binary tree's maximum depth is the number of nodes along 
        /// the longest path from the root node down to the farthest leaf node.
        /// </summary>
        public static TreeNode Execute(TreeNode root)
        {
            if (root == null)
                return null;
            TreeNode left = root.Left;
            TreeNode right = root.Right;
            root.Left = Execute(right);
            root.Right = Execute(left);
            return root;
        }

        public static IEnumerable<(TreeNode root, TreeNode answer)> GetTests()
        {
            yield return (
                TreeNode.Map(4, 2, 7, 1, 3, 6, 9),
                TreeNode.Map(4, 7, 2, 9, 6, 3, 1));
            yield return (
                TreeNode.Map(2, 1, 3),
                TreeNode.Map(2, 3, 1));
            yield return (
                TreeNode.Map(),
                TreeNode.Map());
        }

        public static bool CheckResult(TreeNode result, TreeNode answer)
        {
            return SameTree.Execute(result, answer);
        }
    }
}

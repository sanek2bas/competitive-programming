using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral
{
    public static class MaximumDepthOfBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, return its maximum depth.
        /// A binary tree's maximum depth is the number of nodes along 
        /// the longest path from the root node down to the farthest leaf node.
        /// </summary>
        public static int Execute(TreeNode root)
        {
            if (root == null)
                return 0;
            return 1 + Math.Max(Execute(root.Left), Execute(root.Right));
        }

        public static IEnumerable<(TreeNode root, int answer)> GetTests()
        {
            yield return (
                TreeNode.Map(3, 9, 20, null, null, 15, 7),
                3);
            yield return (
                TreeNode.Map(1, null, 2),
                2);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

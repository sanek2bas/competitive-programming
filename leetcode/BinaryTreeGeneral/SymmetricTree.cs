using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral
{
    public static class SymmetricTree
    {
        /// <summary>
        /// Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
        /// </summary>
        public static bool Execute(TreeNode root)
        {
            if (root == null)
                return true;
            return isSymmetric(root.Left, root.Right);
        }

        private static bool isSymmetric(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && 
                node2 == null)
                return true;

            if (node1 == null ||
                node2 == null ||
                node1.Value != node2.Value)
                return false;

            return isSymmetric(node1.Left, node2.Right) && 
                   isSymmetric(node1.Right, node2.Left);
        }

        public static IEnumerable<(TreeNode root, bool answer)> GetTests()
        {
            yield return (
                TreeNode.Map(1, 2, 2, 3, 4, 4, 3), 
                true);
            yield return (
                TreeNode.Map(1, 2, 2, null, 3, null, 3), 
                false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}

using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral
{
    public static class SameTree
    {
        /// <summary>
        /// Given the roots of two binary trees p and q, write a function to check if they are the same or not.
        /// Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
        /// </summary>
        public static bool Execute(TreeNode p, TreeNode q)
        {
            if (p == null &&
                q == null)
                return true;

            if (p == null ||
                q == null ||
                p.Value != q.Value)
                return false;

            return Execute(p.Left, q.Left) 
                && Execute(p.Right, q.Right);
        }

        public static IEnumerable<(TreeNode root1, TreeNode root2, bool answer)> GetTests()
        {
            yield return (
                TreeNode.Map(1, 2, 3), 
                TreeNode.Map(1, 2, 3), 
                true);
            yield return (
                TreeNode.Map(1, 2, null), 
                TreeNode.Map(1, null, 2), 
                false);
            yield return (
                TreeNode.Map(1, 2, 1), 
                TreeNode.Map(1, 1, 2),                 
                false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}

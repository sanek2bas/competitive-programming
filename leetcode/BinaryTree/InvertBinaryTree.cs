using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral
{
    public static class InvertBinaryTree
    {
        

        public static IEnumerable<(TreeNode root, TreeNode answer)> GetTests()
        {
           
        }

        public static bool CheckResult(TreeNode result, TreeNode answer)
        {
            return SameTree.Execute(result, answer);
        }
    }
}

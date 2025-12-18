using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral
{
    public static class MaximumDepthOfBinaryTree
    {
        

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

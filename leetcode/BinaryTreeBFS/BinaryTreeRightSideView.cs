using Infrastructure;

namespace TopInterview150.BinaryTreeBFS
{
    public static class BinaryTreeRightSideView
    {
        /// <summary>
        /// Given the root of a binary tree, imagine yourself standing on the right side of it,
        /// return the values of the nodes you can see ordered from top to bottom.
        /// </summary>
        public static IList<int> Execute(TreeNode root)
        {
            var answer = new List<int>();
            dfs(root, 0, answer);
            return answer;
        }

        private static void dfs(TreeNode root, int depth, List<int> answer)
        {
            if (root == null)
                return;
            if (depth == answer.Count)
                answer.Add(root.Value);
            dfs(root.Right, depth+1, answer);
            dfs(root.Left, depth+1, answer);
        }

        public static IEnumerable<(TreeNode root, IList<int> answer)> GetTests()
        {
            yield return (
                TreeNode.Map(1, 2, 3, null, 5, null, 4),
                new int[] { 1, 3, 4 });
            yield return (
                TreeNode.Map(1, null, 3),
                new int[] { 1, 3 });
            yield return (
                TreeNode.Map(),
                new int[] { });
            yield return (
                TreeNode.Map(1, 2),
                new int[] { 1, 2 });
        }

        public static bool CheckResult(IList<int> result, IList<int> answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}

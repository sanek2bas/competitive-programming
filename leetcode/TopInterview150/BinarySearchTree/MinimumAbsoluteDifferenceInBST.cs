using Infrastructure;

namespace TopInterview150.BinarySearchTree
{
    public static class MinimumAbsoluteDifferenceInBST
    {
        /// <summary>
        /// Given the root of a Binary Search Tree (BST), 
        /// return the minimum absolute difference between the values of any two different nodes in the tree.
        /// </summary>
        public static int Execute(TreeNode root)
        {
            int answer = int.MaxValue;
            int prevValue = int.MaxValue;
            var queue = new Stack<TreeNode>();
            while (root != null || queue.Count > 0) 
            {
                while(root != null)
                {
                    queue.Push(root);
                    root = root.Left;
                }
                root = queue.Pop();
                answer = Math.Min(answer, Math.Abs(root.Value - prevValue));
                prevValue = root.Value;
                root = root.Right;
            }
            return answer;
        }

        public static IEnumerable<(TreeNode root, int answer)> GetTests()
        {
            yield return (
                TreeNode.Map(4, 2, 6, 1, 3),
                1);
            yield return (
                TreeNode.Map(1, 0, 48, null, null, 12, 49),
                1);
            yield return (
                TreeNode.Map(3, 1, 4, null, 2),
                1);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

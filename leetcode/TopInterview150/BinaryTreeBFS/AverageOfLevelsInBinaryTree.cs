using Infrastructure;

namespace TopInterview150.BinaryTreeBFS
{
    public static class AverageOfLevelsInBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, return the average value of the nodes on each level in the form of an array. 
        /// Answers within 10-5 of the actual answer will be accepted.
        /// </summary>
        public static IList<double> Execute(TreeNode root)
        {
            var answer = new List<double>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0) 
            {
                long sum = 0;
                var queueCount = queue.Count();
                for (int i = 0; i < queueCount; i++) 
                {
                    var node = queue.Dequeue();
                    sum += node.Value;
                    if (node.Left != null)
                        queue.Enqueue(node.Left);
                    if (node.Right != null)
                        queue.Enqueue(node.Right);
                }
                answer.Add(sum / (double)queueCount);
            }
            return answer;
        }

        public static IEnumerable<(TreeNode root, double[] answer)> GetTests()
        {
            yield return (
                TreeNode.Map(3, 9, 20, null, null, 15, 7),
                new double[] { 3.00, 14.50, 11.00 });
            yield return (
                TreeNode.Map(3, 9, 20, 15, 7),
                new double[] { 3.00, 14.50, 11.00 });
        }

        public static bool CheckResult(IList<double> result, double[] answer)
        {
            if (result.Count != answer.Length)
                return false;
            return result.SequenceEqual(answer);
        }
    }
}

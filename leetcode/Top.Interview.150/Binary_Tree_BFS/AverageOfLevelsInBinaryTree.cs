using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_BFS;

public class AverageOfLevelsInBinaryTree
{
    /// <summary>
    /// # 637
    /// https://leetcode.com/problems/average-of-levels-in-binary-tree/description/
    /// Given the root of a binary tree, return the average value of the nodes 
    /// on each level in the form of an array. Answers within 10-5 of the actual 
    /// answer will be accepted.
    /// </summary>
    public IList<double> Execute(TreeNode? root)
    {
        var result = new List<double>();
        if (root == null) 
            return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) 
        {
            int levelSize = queue.Count;
            double levelSum = 0;

            for (int i = 0; i < levelSize; i++) 
            {
                TreeNode currentNode = queue.Dequeue();
                levelSum += currentNode.Value;

                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);
                
                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
            }

            result.Add(levelSum / levelSize);
        }

        return result;
    }
}
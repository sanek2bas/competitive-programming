using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_BFS;

public class BinaryTreeZigzagLevelOrderTraversal
{
    /// <summary>
    /// # 103
    /// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
    /// Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. 
    /// (i.e., from left to right, then right to left for the next level and alternate between).
    /// </summary>
    public IList<IList<int>> Execute(TreeNode? root)
    {
        var result = new List<IList<int>>();
        if (root == null)
            return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool leftToRight = true;

        while (queue.Count > 0) 
        {
            int levelSize = queue.Count;
            int[] currentLevel = new int[levelSize];

            for (int i = 0; i < levelSize; i++) 
            {
                TreeNode currentNode = queue.Dequeue();

                int index = leftToRight 
                    ? i 
                    : (levelSize - 1 - i);
                currentLevel[index] = currentNode.Value;

                if (currentNode.Left != null) 
                    queue.Enqueue(currentNode.Left);
                if (currentNode.Right != null) 
                    queue.Enqueue(currentNode.Right);
            }

            result.Add(currentLevel);
            leftToRight = !leftToRight;
        }

        return result;
    }
}
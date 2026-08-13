using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_BFS;

public class BinaryTreeRightSideView
{
    /// <summary>
    /// # 199
    /// https://leetcode.com/problems/binary-tree-right-side-view/description/
    /// Given the root of a binary tree, imagine yourself standing 
    /// on the right side of it, return the values of the nodes 
    /// you can see ordered from top to bottom.
    /// </summary>
    public IList<int> Execute(TreeNode? root)
    {
        var result = new List<int>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) 
        {
            int levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++) 
            {
                TreeNode currentNode = queue.Dequeue();
                if (i == levelSize - 1)
                    result.Add(currentNode.Value);

                if (currentNode.Left != null) 
                    queue.Enqueue(currentNode.Left);
                
                if (currentNode.Right != null) 
                    queue.Enqueue(currentNode.Right);
            }
        }

        return result;
    }
}
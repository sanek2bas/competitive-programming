using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_BFS;

public class BinaryTreeLevelOrderTraversal
{
    /// <summary>
    /// # 102
    /// https://leetcode.com/problems/binary-tree-level-order-traversal/description/
    /// Given the root of a binary tree, return the level order traversal 
    /// of its nodes' values. (i.e., from left to right, level by level).
    /// </summary>
    public IList<IList<int>> Execute(TreeNode? root)
    {
        var result = new List<IList<int>>();
        
        if (root == null)
            return result;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0) 
        {
            int levelSize = queue.Count;
            var currentLevelList = new List<int>();
            
            for (int i = 0; i < levelSize; i++) 
            {
                TreeNode currentNode = queue.Dequeue();
                currentLevelList.Add(currentNode.Value);
                
                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);

                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
            }
            
            result.Add(currentLevelList);
        }
        
        return result;   
    }
}
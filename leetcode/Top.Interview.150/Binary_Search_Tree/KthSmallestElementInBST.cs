using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Search_Tree;

public class KthSmallestElementInBST
{
    /// <summary>
    /// # 230
    /// https://leetcode.com/problems/kth-smallest-element-in-a-bst/description/
    /// Given the root of a binary search tree, and an integer k, 
    /// return the kth smallest value (1-indexed) of all the values 
    /// of the nodes in the tree.
    /// </summary>
    public int Execute(TreeNode? root, int k)
    {
        var stack = new Stack<TreeNode>();
        TreeNode current = root;

        while (current != null || stack.Count > 0) 
        {
            while (current != null) 
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            k--;
            
            if (k == 0)
                return current.Value;

            current = current.Right;
        }

        return -1;
    }
}
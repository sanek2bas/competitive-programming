using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Search_Tree;

public class ValidateBinarySearchTree
{
    /// <summary>
    /// # 98
    /// https://leetcode.com/problems/validate-binary-search-tree/description/
    /// Given the root of a binary tree, determine if it is a valid binary search tree (BST).
    /// A valid BST is defined as follows:
    /// The left subtree of a node contains only nodes with keys strictly 
    /// less than the node's key.
    /// The right subtree of a node contains only nodes with keys strictly 
    /// greater than the node's key.
    /// Both the left and right subtrees must also be binary search trees.
    /// </summary>
    public bool Execute(TreeNode? root)
    {
        return IsValid(root, null, null);
    }

    private bool IsValid(TreeNode? node, long? min, long? max)
    {
        if (node == null)
            return true;
        
        if (min != null && node.Value <= min)
            return false;

        if (max != null && node.Value >= max)
            return false;
        
        return IsValid(node.Left, min, node.Value)
            && IsValid(node.Right, node.Value, max);
    }
}
using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_General;

public class LowestCommonAncestorOfBinaryTree
{
    /// <summary>
    /// # 236
    /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
    /// Given a binary tree, find the lowest common ancestor (LCA) of 
    /// two given nodes in the tree.
    /// According to the definition of LCA on Wikipedia: “The lowest common 
    /// ancestor is defined between two nodes p and q as the lowest node 
    /// in T that has both p and q as descendants (where we allow a node 
    /// to be a descendant of itself).”
    /// </summary>
    public TreeNode Execute(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null 
            || root.Value == p.Value 
            || root.Value == q.Value) 
            return root;

        TreeNode left = Execute(root.Left, p, q);
        TreeNode right = Execute(root.Right, p, q);

        if (left != null 
            && right != null)
            return root;

        return left != null ? left : right;
    }
}
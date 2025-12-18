using Top.Interview._150.Common;

namespace Top.Interview._150.Binary_Tree_General;

public class InvertBinaryTree
{
    /// <summary>
    /// # 226
    /// https://leetcode.com/problems/invert-binary-tree/description/
    /// Given the root of a binary tree, return its maximum depth.
    /// A binary tree's maximum depth is the number of nodes along 
    /// the longest path from the root node down to the farthest leaf node.
    /// </summary>
    public TreeNode Execute(TreeNode root)
    {
        if (root == null)
            return null;
        TreeNode left = root.Left;
        TreeNode right = root.Right;
        root.Left = Execute(right);
        root.Right = Execute(left);
        return root;
    }
}
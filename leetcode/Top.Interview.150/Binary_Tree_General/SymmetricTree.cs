using Top.Interview._150.Common;

public class SymmetricTree
{
    /// <summary>
    /// # 101
    /// https://leetcode.com/problems/symmetric-tree/description/
    /// Given the root of a binary tree, check whether 
    /// it is a mirror of itself (i.e., symmetric around its center).
    /// </summary>
    public bool Execute(TreeNode root)
    {
        if (root == null)
            return true;
        return IsSymmetric(root.Left, root.Right);
    }

    private bool IsSymmetric(TreeNode node1, TreeNode node2)
    {
        if (node1 == null 
            && node2 == null)
            return true;

        if (node1 == null 
            || node2 == null 
            || node1.Value != node2.Value)
            return false;

        return IsSymmetric(node1.Left, node2.Right) 
            && IsSymmetric(node1.Right, node2.Left);
    }
}
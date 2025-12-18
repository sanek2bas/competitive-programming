using Top.Interview._150.Common;

public class PathSum
{
    /// <summary>
    /// # 112
    /// https://leetcode.com/problems/path-sum/description/
    /// Given the root of a binary tree and an integer targetSum, 
    /// return true if the tree has a root-to-leaf path such that 
    /// adding up all the values along the path equals targetSum.
    /// A leaf is a node with no children.
    /// </summary>
    public bool Execute(TreeNode root, int targetSum)
    {
        if (root == null)
            return false;

        if (root.Value == targetSum 
            && root.Left == null
            && root.Right == null)
            return true;
        
        return Execute(root.Left, targetSum - root.Value)
            || Execute(root.Right, targetSum - root.Value);
    }
}
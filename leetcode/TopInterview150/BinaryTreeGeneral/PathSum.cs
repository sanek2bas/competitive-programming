using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral;

public static class PathSum
{
    /// <summary>
    /// Given the root of a binary tree and an integer targetSum, return true 
    /// if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.
    /// A leaf is a node with no children.
    /// </summary>
    public static bool Execute(TreeNode root, int targetSum)
    {
        if (root == null)
            return false;
        if (root.Value == targetSum && 
            root.Left == null && 
            root.Right == null)
            return true;
        
        return
            Execute(root.Left, targetSum - root.Value) ||
            Execute(root.Right, targetSum - root.Value);
    }

    public static IEnumerable<(TreeNode root, int targetSum, bool answer)> GetTests()
    {
        yield return (TreeNode.Map(5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1), 22, true);
        yield return (TreeNode.Map(1, 2, 3), 5, false);
        yield return (TreeNode.Map(), 0, false);
    }

    public static bool CheckResult(bool result, bool answer)
    {
        return result == answer;
    }
}

using Infrastructure;

namespace TopInterview150.BinaryTreeGeneral;

public static class CountCompleteTreeNodes
{
    /// <summary>
    /// Given the root of a complete binary tree, return the number of the nodes in the tree.
    /// According to Wikipedia, every level, except possibly the last, is completely filled in a complete binary tree, 
    /// and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.
    /// Design an algorithm that runs in less than O(n) time complexity.
    /// </summary>
    public static int Execute(TreeNode root)
    {
        if (root == null)
            return 0;
        TreeNode left = root;
        TreeNode right = root;
        int leftHeight = 0;
        int rightHeight = 0;
        while(left != null)
        {
            leftHeight++;
            left = left.Left;
        }
        while(right != null)
        {
            rightHeight++;
            right = right.Right;
        }
        if(leftHeight == rightHeight)
            return (int)Math.Pow(2, leftHeight) - 1;
        return Execute(root.Left) + Execute(root.Right) + 1;
    }

    public static IEnumerable<(TreeNode root, int answer)> GetTests()
    {
        yield return (TreeNode.Map(1, 2, 3, 4, 5, 6), 6);
        yield return (TreeNode.Map(), 0);
        yield return (TreeNode.Map(1), 1);
    }

    public static bool CheckResult(int result, int answer)
    {
        return result == answer;
    }
}

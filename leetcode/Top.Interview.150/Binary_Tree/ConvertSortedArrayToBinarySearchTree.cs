namespace Top.Interview._150.Binary_Tree;

public class ConvertSortedArrayToBinarySearchTree
{
    /// <summary>
    /// # 108
    /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
    /// Given an integer array nums where the elements 
    /// are sorted in ascending order, 
    /// convert it to a height-balanced binary search tree.
    /// </summary>
    public TreeNode Execute(int[] nums)
    {
        return Build(nums, 0, nums.Length - 1);
    }

    private TreeNode Build(int[] nums, int l, int r)
    {
        if (l > r)
            return null;
        int m = (l + r) / 2;
        var node = new TreeNode(nums[m]);
        node.Left = Build(nums, l, m - 1);
        node.Right = Build(nums, m + 1, r);
        return node;
    }

    public static IEnumerable<(int[] nums, (TreeNode node1, TreeNode node2) answer)> GetTests()
    {
        yield return (
            new int[] { -10, -3, 0, 5, 9 },
            (TreeNode.Map(0, -3, 9, -10, null, 5),
                TreeNode.Map(0, -10, 5, null, -3, null, 9)));
        yield return (
            new int[] { 1, 3 },
            (TreeNode.Map(3, 1),
                TreeNode.Map(1, null, 3)));
    }

    public static bool CheckResult(TreeNode result, (TreeNode node1, TreeNode node2) answer)
    {
        var resultArray = TreeNode.ToArray(result);
        var answer1Array = TreeNode.ToArray(answer.node1);
        var answer2Array = TreeNode.ToArray(answer.node2);
        return resultArray.SequenceEqual(answer1Array)
            || resultArray.SequenceEqual(answer2Array);
    }
}
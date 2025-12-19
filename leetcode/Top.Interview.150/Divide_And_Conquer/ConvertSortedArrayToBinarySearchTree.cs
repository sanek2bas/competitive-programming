using Top.Interview._150.Common;

namespace Top.Interview._150.Divide_And_Conquer;

public class ConvertSortedArrayToBinarySearchTree
{
    /// <summary>
    /// # 108
    /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
    /// Given an integer array nums where the elements are 
    /// sorted in ascending order, convert it to a height-balanced 
    /// binary search tree.
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
        var node = CreateTreeNode(nums[m]);
        node.Left = Build(nums, l, m - 1);
        node.Right = Build(nums, m + 1, r);
        return node;
    }

    private TreeNode CreateTreeNode(int number)
    {
        return TreeNode.Create(number);
    }
}
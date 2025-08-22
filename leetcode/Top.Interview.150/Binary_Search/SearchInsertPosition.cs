namespace Top.Interview._150.Binary_Search;

public class SearchInsertPosition
{
    /// <summary>
    /// # 35
    /// https://leetcode.com/problems/search-insert-position/description/
    /// Given a sorted array of distinct integers and a target value,
    /// return the index if the target is found.
    /// If not, return the index where it would be if it were inserted in order.
    /// You must write an algorithm with O(log n) runtime complexity.
    /// </summary>
    public int Execute(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length;
        while (left < right)
        {
            int middle = (left + right) / 2;
            if (nums[middle] == target)
                return middle;
            if (nums[middle] < target)
                left = middle + 1;
            else
                right = middle;
        }
        return left;
    }
}

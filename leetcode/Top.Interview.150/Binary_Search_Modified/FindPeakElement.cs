namespace Top.Interview._150.Binary_Search;

public class FindPeakElement
{
    /// <summary>
    /// # 162
    /// https://leetcode.com/problems/find-peak-element/description/
    /// A peak element is an element that is strictly greater than its neighbors.
    /// Given a 0-indexed integer array nums, find a peak element, and return its index.
    /// If the array contains multiple peaks, return the index to any of the peaks.
    /// You may imagine that nums[-1] = nums[n] = -∞. 
    /// In other words, an element is always considered to be strictly 
    /// greater than a neighbor that is outside the array.
    /// You must write an algorithm that runs in O(log n) time.
    /// </summary>
    public int Execute(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var m = (left + right) / 2;
            if (nums[m] >= nums[m + 1])
                right = m;
            else
                left = m + 1;
        }

        return left;
    }
}

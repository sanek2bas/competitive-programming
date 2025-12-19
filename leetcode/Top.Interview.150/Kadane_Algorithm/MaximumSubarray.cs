namespace Top.Interview._150.Kadane_Algorithm;

public class MaximumSubarray
{
    /// <summary
    /// # 53
    /// https://leetcode.com/problems/maximum-subarray/description/
    /// Given an integer array nums, find the subarray with the largest sum, 
    /// and return its sum.
    /// </summary>
    public int Execute(int[] nums)
    {
        int[] dp = new int[nums. Length];
        dp[0] = nums[0];            
        for (int i = 1; i < nums.Length; i++)
            dp[i] = Math.Max(nums[i], dp[i - 1] + nums[i]);
        return dp.Max();
    }
}
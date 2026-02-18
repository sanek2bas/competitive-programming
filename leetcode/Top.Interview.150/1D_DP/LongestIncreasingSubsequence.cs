using System.Reflection.Metadata;
using Top.Interview._150.Binary_Tree_General;

namespace Top.Interview._150._1D_DP;

public class LongestIncreasingSubsequence
{
    /// <summary>
    /// # 300
    /// https://leetcode.com/problems/longest-increasing-subsequence/description
    /// Given an integer array nums, return the length 
    /// of the longest strictly increasing subsequen
    /// </summary>
    public int Execute(int[] nums)
    {
        if (nums == null
            || nums.Length == 0)
            return 0;

        int[] dp = new int[nums.Length];
        int length = 0;

        foreach (int num in nums)
        {
            int i = Array.BinarySearch(dp, 0, length, num);
            if (i < 0)
                i = ~i;
        }

               
    }
}
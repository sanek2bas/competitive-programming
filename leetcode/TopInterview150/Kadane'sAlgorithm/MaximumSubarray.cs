using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150.Kadane_sAlgorithm
{
    public static class MaximumSubarray
    {
        /// <summary
        /// Given an integer array nums, find the subarray with the largest sum, and return its sum.
        /// </summary>
        public static int Execute(int[] nums)
        {
            int[] dp = new int[nums. Length];
            dp[0] = nums[0];            
            for (int i = 1; i < nums.Length; i++)
                dp[i] = Math.Max(nums[i], dp[i - 1] + nums[i]);
            return dp.Max();
        }

        public static IEnumerable<(int[] nums, int answer)> GetTests()
        {
            yield return (new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6);
            yield return (new int[] { 1 }, 1);
            yield return (new int[] { 5, 4, -1, 7, 8 }, 23);
        }

        public static bool CheckResult(int target, int answer)
        {
            return target == answer;
        }
    }
}

﻿namespace TopInterview150.Array_String
{
    public static class JumpGameII
    {
        /// <summary>
        /// You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].
        /// Each element nums[i] represents the maximum length of a forward jump from index i.In other words, 
        /// if you are at nums[i], you can jump to any nums[i + j] where: 0 <= j <= nums[i] and i + j<n.
        /// Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].
        /// </summary>
        public static int Execute(int[] nums)
        {
            int answer = 0;
            int end = 0;
            int farthest = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                farthest = Math.Max(farthest, i + nums[i]);
                if (farthest >= nums.Length - 1)
                {
                    answer++;
                    break;
                }
                if (i == end)
                {
                    answer++;          
                    end = farthest; 
                }
            }
            return answer;
        }

        public static IEnumerable<(int[] nums, int answer)> GetTests()
        {
            yield return (new int[] { 2, 3, 1, 1, 4 }, 2);
            yield return (new int[] { 2, 3, 0, 1, 4 }, 2);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

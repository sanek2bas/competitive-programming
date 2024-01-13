namespace TopInterview150.SlidingWindow
{
    public static class MinimumSizeSubarraySum
    {
        /// <summary>
        /// Given an array of positive integers nums and a positive integer target, return the minimal length of a subarray
        /// whose sum is greater than or equal to target.If there is no such subarray, return 0 instead.
        /// </summary>
        public static int Execute(int target, int[] nums)
        {
            int answer = int.MaxValue;
            int sum = 0;
            int left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right];
                while (sum >= target)
                {
                    answer = Math.Min(answer, right - left + 1);
                    sum -= nums[left++];
                }                
            }
            return answer == int.MaxValue ? 0 : answer;
        }

        public static IEnumerable<(int val, int[] nums, int answer)> GetTests()
        {
            yield return (7, new int[] { 2, 3, 1, 2, 4, 3 }, 2);
            yield return (4, new int[] { 1, 4, 4 }, 1);
            yield return (11, new int[] { 1, 4, 4 }, 0);
        }

        public static bool CheckResult(int target, int answer)
        {
            return answer == target;
        }
    }
}

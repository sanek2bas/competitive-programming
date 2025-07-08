namespace Interview.PrefixSum
{
    public class MinimumSizeSubarraySum
    {
        /// <summary>
        /// Given an array of positive integers nums and a positive integer target, return the minimal length of a 
        /// subarray whose sum is greater than or equal to target.If there is no such subarray, return 0 instead.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Execute(int target, int[] nums)
        {
            int answer = int.MaxValue;
            int left = 0;
            int sum = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right];
                while(sum >= target)
                {
                    answer = Math.Min(answer, right - left + 1);
                    sum -= nums[left++];
                }
            }

            return answer == int.MaxValue ? 0 : answer;
        }

        public static IEnumerable<(int target, int[] numbers, int answer)> GetTests()
        {
            yield return (
                7, 
                new int[] { 2, 3, 1, 2, 4, 3 }, 
                2);
            yield return (
                4, 
                new int[] { 1, 4, 4 }, 
                1);
            yield return (
                11, 
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
                0);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

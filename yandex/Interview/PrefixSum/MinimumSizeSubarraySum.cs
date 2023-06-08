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
            int currSum = 0;
            int minLength = nums.Length + 1;
            int numsLength = nums.Length;
            int start = 0;
            int end = 0;

            while (end < numsLength)
            {
                while (currSum < target && end < numsLength)
                    currSum += nums[end++];

                while (currSum >= target && start < end)
                {
                    if (end - start < minLength)
                        minLength = end - start;
                    currSum -= nums[start++];
                }
            }
            return minLength == nums.Length + 1 ? 0 : minLength; 
        }

        public static IEnumerable<(int target, int[] numbers, int answer)> GetTests()
        {
            yield return (7, new int[] { 2, 3, 1, 2, 4, 3 }, 2);
            yield return (4, new int[] { 1, 4, 4 }, 1);
            yield return (11, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 0);
        }
    }
}

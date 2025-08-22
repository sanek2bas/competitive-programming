namespace TopInterview150.Array_String
{
    public static class ProductOfArrayExceptSelf
    {
        /// <summary>
        /// Given an integer array nums, return an array answer such that answer[i] is 
        /// equal to the product of all the elements of nums except nums[i].
        /// 
        /// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        /// You must write an algorithm that runs in O(n) time and without using the division operation.
        /// </summary>
        public static int[] Execute(int[] nums)
        {
            var n = nums.Length;
            var answer = new int[n];
            var prefix = new int[n];
            var suffix = new int[n];

            prefix[0] = 1;
            for(int i = 1; i < n; i++)
                prefix[i] = prefix[i - 1] * nums[i - 1];

            suffix[n-1] = 1;
            for(int i = n-2; i >= 0; i--)
                suffix[i] = suffix[i + 1] * nums[i + 1];

            for (int i = 0; i < n; i++)
                answer[i] = prefix[i] * suffix[i];

            return answer;
        }

        public static IEnumerable<(int[] nums, int[] answer)> GetTests()
        {
            yield return (
                new int[] { 1, 2, 3, 4 },
                new int[] { 24, 12, 8, 6 });
            yield return (
                new int[] { -1, 1, 0, -3, 3 },
                new int[] { 0, 0, 9, 0, 0 });
        }

        public static bool CheckResult(int[] result, int[] answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}

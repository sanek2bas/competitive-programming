namespace Interview.PrefixSum
{
    public static class ProductOfArrayExceptSelf
    {
        /// <summary>
        /// Given an integer array nums, return an array answer such that answer[i]
        /// is equal to the product of all the elements of nums except nums[i].
        /// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        /// You must write an algorithm that runs in O(n) time and without using the division operation.
        /// </summary>
        public static int[] Execute(int[] nums)
        {
            int n = nums.Length;
            var prefix = new int[n];
            var suffix = new int[n];

            prefix[0] = 1;
            for (int i = 1; i < n; i++)
                prefix[i] = prefix[i - 1] * nums[i - 1];

            suffix[n - 1] = 1;
            for(int j = n - 2; j >= 0; j--)
                suffix[j] = suffix[j + 1] * nums[j + 1];

            var result = new int[n];
            for(int k = 0; k < n; k++)
                result[k] = suffix[k] * prefix[k];

            return result;
        }

        public static IEnumerable<(int[] numbers, int[] answer)> GetTests()
        {
            yield return (
                new int[] { 1, 2, 3, 4 },
                new int[] { 24, 12, 8, 6 });
            yield return (
                new int[] { 1, 2, 3, 4 },
                new int[] { 24, 12, 8, 6 });
        }

        public static bool CheckResult(int[] result, int[] answer)
        {
            if (result.Length != answer.Length)
                return false;
            return result.SequenceEqual(answer);
        }
    }
}

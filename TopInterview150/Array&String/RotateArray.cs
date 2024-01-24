namespace TopInterview150.Array_String
{
    public static class RotateArray
    {
        /// <summary>
        /// Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
        /// </summary>
        public static void Execute(int[] nums, int k)
        {
            k %= nums.Length;
            reverse(nums, 0, nums.Length - 1);
            reverse(nums, 0, k - 1);
            reverse(nums, k, nums.Length - 1);
        }

        private static void reverse(int[] nums, int left, int right)
        {
            while (left < right)
                swap(nums, left++, right--);
        }

        private static void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public static IEnumerable<(int[] nums, int k, int[] answer)> GetTests()
        {
            yield return (new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3,
                          new int[] { 5, 6, 7, 1, 2, 3, 4 });
            yield return (new int[] { -1, -100, 3, 99 }, 2,
                          new int[] { 3, 99, -1, -100 });
        }

        public static bool CheckResult(int[] result, int[] answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}

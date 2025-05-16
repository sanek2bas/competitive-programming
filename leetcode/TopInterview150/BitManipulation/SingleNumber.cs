namespace TopInterview150.BitManipulation
{
    public static class SingleNumber
    {
        /// <summary>
        /// Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
        /// You must implement a solution with a linear runtime complexity and use only constant extra space.
        /// </summary>
        public static int Execute(int[] nums)
        {
            int result = 0;
            foreach (int num in nums)
                result ^= num;
            return result;
        }

        public static IEnumerable<(int[] nums, int answer)> GetTests()
        {
            yield return (
                new int[] { 2, 2, 1 },
                1);
            yield return (
                new int[] { 4, 1, 2, 1, 2 },
                4);
            yield return (
                new int[] { 1 }, 
                1);

        }

        public static bool CheckResult(int result, int answer)
        {
            return answer == result;
        }
    }
}

namespace TopInterview150.Array_String
{
    public static class JumpGame
    {
        /// <summary>
        /// You are given an integer array nums. You are initially positioned at the array's first index,
        /// and each element in the array represents your maximum jump length at that position.
        /// Return true if you can reach the last index, or false otherwise.
        /// </summary>
        public static bool Execute(int[] nums)
        {
            int goal = nums.Length - 1;
            for(int i = nums.Length - 2; i >= 0; i--)
            {
                if (i + nums[i] >= goal)
                    goal = i;
            }
            return goal == 0;
        }

        public static IEnumerable<(int[] nums, bool answer)> GetTests()
        {
            yield return (new int[] { 2, 3, 1, 1, 4 }, true);
            yield return (new int[] { 3, 2, 1, 0, 4 }, false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}

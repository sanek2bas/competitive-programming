namespace TopInterview150.Array_String
{
    public static class MajorityElement
    {
        /// <summary>
        /// Given an array nums of size n, return the majority element.
        /// The majority element is the element that appears more than ⌊n / 2⌋ times.
        /// You may assume that the majority element always exists in the array.
        /// </summary>
        public static int Execute(int[] nums)
        {
            int curr = nums[0];
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (count == 0)
                    curr = nums[i];
                count += curr == nums[i] ? +1 : -1;
            }
            return curr;
        }

        public static IEnumerable<(int[] nums, int answer)> GetTests()
        {
            yield return (
                new int[] { 3, 2, 3 },
                3);
            yield return (
                new int[] { 2, 2, 1, 1, 1, 2, 2 },
                2);
            yield return (
                new int[] { 2, 2, 2, 2, 1, 1, 0, 7 },
                2);
        }

        public static bool CheckResult(int target, int answer)
        {
            return answer == target;
        }
    }
}

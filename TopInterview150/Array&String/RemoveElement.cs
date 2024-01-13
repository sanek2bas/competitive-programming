namespace TopInterview150.Array_String
{
    public static class RemoveElement
    {
        /// <summary>
        /// Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. 
        /// The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.
        /// </summary>
        public static int Execute(int[] nums, int val)
        {
            var count = 0;
            foreach (int num in nums)
            {
                if (num == val)
                    continue;
                nums[count] = num;
                count++;
            }
            return count;
        }

        public static IEnumerable<(int[] nums, int val, int[] answer)> GetTests()
        {
            yield return (
                new int[] { 3, 2, 2, 3 }, 3,
                new int[] { 2, 2 });
            yield return (
                new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2,
                new int[] { 0, 1, 3, 0, 4 });
        }

        public static bool CheckResult(int[] result, int resultCount, int[] answer)
        {
            return answer.Length == resultCount
                && answer.SequenceEqual(result.Take(resultCount));
        }
    }
}

namespace TopInterview150.Array_String
{
    public static class RemoveDuplicatesFromSortedArray
    {
        /// <summary>
        /// Given an integer array nums sorted in non-decreasing order, 
        /// remove the duplicates in-place such that each unique element appears only once. 
        /// The relative order of the elements should be kept the same. 
        /// Then return the number of unique elements in nums.
        /// </summary>
        public static int Execute(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int count = 1;
            int curr = nums[0];
            foreach (int num in nums)
            {
                if (num == curr)
                    continue;
                nums[count] = num;
                count++;
                curr = num;
            }
            return count;
        }

        public static IEnumerable<(int[] nums, int[] answer)> GetTests()
        {
            yield return (
                new int[] { 1, 1, 2 },
                new int[] { 1, 2 });
            yield return (
                new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 },
                new int[] { 0, 1, 2, 3, 4 });
        }

        public static bool CheckResult(int[] target, int targetCount, int[] answer)
        {
            return answer.Length == targetCount 
                && answer.SequenceEqual(target.Take(targetCount));
        }
    }
}

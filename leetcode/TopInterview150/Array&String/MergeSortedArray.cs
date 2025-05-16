namespace TopInterview150.Array_String
{
    public static class MergeSortedArray
    {
        /// <summary>
        /// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, 
        /// representing the number of elements in nums1 and nums2 respectively.
        /// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
        /// The final sorted array should not be returned by the function, but instead be stored inside the array nums1.
        /// To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged,
        /// and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
        /// </summary>
        public static void Execute(int[] nums1, int m, int[] nums2, int n)
        {
            m--;
            n--;
            for (int i = m+n+1; i >= 0; i--)
            {
                if (n < 0)
                    break;
                nums1[i] = m >= 0 && nums1[m] > nums2[n]
                         ? nums1[i] = nums1[m--]
                         : nums1[i] = nums2[n--];
            }
        }

        public static IEnumerable<(int[] nums1, int m, int[] nums2, int n, int[] answer)> GetTests()
        {
            yield return (
                new int[] { 1, 2, 3, 0, 0, 0 }, 3,
                new int[] { 2, 5, 6 }, 3,
                new int[] { 1, 2, 2, 3, 5, 6 });
            yield return (
                new int[] { 1 }, 1,
                new int[] { }, 0,
                new int[] { 1 });
            yield return (
                new int[]{ 0 }, 0, 
                new int[] { 1 }, 1,
                new int[] { 1 });
        }

        public static bool CheckResult(int[] result, int[] answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}

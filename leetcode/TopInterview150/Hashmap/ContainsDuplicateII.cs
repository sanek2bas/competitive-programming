namespace TopInterview150.Hashmap;

public static class ContainsDuplicateII
{
    /// <summary>
    /// Given an integer array nums and an integer k, 
    /// return true if there are two distinct indices i and j 
    /// in the array such that nums[i] == nums[j] and abs(i - j) <= k.
    /// </summary>
    public static bool Execute(int[] nums, int k)
    {
        var seen = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++) 
        {
            if (seen.Contains(nums[i]))
                return true;
            else
                seen.Add(nums[i]);
            if (i >= k)
                seen.Remove(nums[i - k]);
        }
        return false;
    }

    public static IEnumerable<(int[] nums, int k, bool answer)> GetTests()
    {
        yield return (new int[] { 1, 2, 3, 1 }, 3, true);
        yield return (new int[] { 1, 0, 1, 1 }, 1, true);
        yield return (new int[] { 1, 2, 3, 1, 2, 3 }, 2, false);
    }

    public static bool CheckResult(bool result, bool answer)
    {
        return result == answer;
    }
}

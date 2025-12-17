namespace Top.Interview._150.Hashmap;

public class ContainsDuplicate2
{
    /// <summary>
    /// # 219
    /// https://leetcode.com/problems/contains-duplicate-ii/
    /// Given an integer array nums and an integer k, 
    /// return true if there are two distinct indices i and j 
    /// in the array such that nums[i] == nums[j] and abs(i - j) <= k.
    /// </summary>
    public bool Execute(int[] nums, int k)
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
}
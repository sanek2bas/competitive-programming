namespace Top.Interview._150.Array_String;

public class RemoveDuplicatesFromSortedArray
{
    /// <summary>
    /// # 26
    /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
    /// Given an integer array nums sorted in non-decreasing order, 
    /// remove the duplicates in-place such that each unique element 
    /// appears only once. The relative order of the elements 
    /// should be kept the same. Then return the number of unique 
    /// elements in nums.
    /// </summary>
    public int Execute(int[] nums)
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
}
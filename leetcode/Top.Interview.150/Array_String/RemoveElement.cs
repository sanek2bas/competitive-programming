namespace Top.Interview._150.Array_String;

public class RemoveElement
{
    /// <summary>
    /// # 27
    /// https://leetcode.com/problems/remove-element/description/
    /// Given an integer array nums and an integer val,
    ///  remove all occurrences of val in nums in-place. 
    /// The order of the elements may be changed. 
    /// hen return the number of elements in nums which are not equal to val.
    /// </summary>
    public int Execute(int[] nums, int val)
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
}
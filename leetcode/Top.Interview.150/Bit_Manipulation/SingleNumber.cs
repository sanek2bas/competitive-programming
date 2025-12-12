namespace Top.Interview._150.Bit_Manipulation;

public class SingleNumber
{
    /// <summary>
    /// # 136
    /// https://leetcode.com/problems/single-number/
    /// Given a non-empty array of integers nums, 
    /// every element appears twice except for one. 
    /// Find that single one.
    /// You must implement a solution with a linear 
    /// runtime complexity and use only constant extra space.
    /// </summary>
    public int Execute(int[] nums)
    {
        int result = 0;
        foreach (int num in nums)
            result ^= num;
        return result;
    }
}
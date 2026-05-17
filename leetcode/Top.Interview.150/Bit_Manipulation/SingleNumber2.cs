namespace Top.Interview._150.Bit_Manipulation;

public class SingleNumber2
{
    /// <summary>
    /// # 137
    /// https://leetcode.com/problems/single-number-ii/description/
    /// Given an integer array nums where every element appears three 
    /// times except for one, which appears exactly once. 
    /// Find the single element and return it.
    /// You must implement a solution with a linear runtime complexity 
    /// and use only constant extra space.
    /// </summary>
    public int Execute(int[] nums)
    {
        int result = 0;
        for (int i = 0; i < 32; ++i) 
        {
            int sum = 0;
            foreach (int num in nums)
                sum += num >> i & 1;
            sum %= 3;
            result |= sum << i;
        }
        return result;
    }
}
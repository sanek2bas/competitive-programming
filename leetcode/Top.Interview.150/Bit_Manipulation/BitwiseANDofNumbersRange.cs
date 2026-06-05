namespace Top.Interview._150.Bit_Manipulation;

public class BitwiseANDofNumbersRange
{
    /// <summary>
    /// # 201
    /// https://leetcode.com/problems/bitwise-and-of-numbers-range/description/
    /// Given two integers left and right that represent the range [left, right], 
    /// return the bitwise AND of all numbers in this range, inclusive.
    /// </summary>
    public int Execute(int left, int right)
    {
        while(right > left)
            right &= right - 1;
        return right;
    }
}
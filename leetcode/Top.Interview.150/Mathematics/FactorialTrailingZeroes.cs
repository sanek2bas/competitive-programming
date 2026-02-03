namespace Top.Interview._150.Mathematics;

public class FactorialTrailingZeroes
{
    /// <summary>
    /// # 172
    /// https://leetcode.com/problems/factorial-trailing-zeroes/description/
    /// Given an integer n, return the number of trailing zeroes in n!.
    /// Note that n! = n * (n - 1) * (n - 2) * ... * 3 * 2 * 1.
    /// </summary>
    public int Execute(int n)
    {
        int result = 0;
        for(int i = 5; n/i >= 1; i *= 5)
            result += n/i;
        return result;
    }
}
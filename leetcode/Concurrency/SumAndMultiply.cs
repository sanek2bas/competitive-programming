namespace Concurrency;

/// <summary>
/// # 3754
/// https://leetcode.com/problems/concatenate-non-zero-digits-and-multiply-by-sum-i/description/
/// You are given an integer n.
/// Form a new integer x by concatenating all the non-zero digits of n in their 
/// original order. If there are no non-zero digits, x = 0.
/// Let sum be the sum of digits in x.
/// Return an integer representing the value of x * sum.
/// </summary>
public class SumAndMultiply
{
    public long Execute(int n)
    {
        long x = 0;
        long sum = 0;
        long multiplier = 1;
        
        while (n > 0) 
        {
            int digit = n % 10;
            if (digit != 0) 
            {
                x = digit * multiplier + x;
                sum += digit;
                multiplier *= 10;
            }
            n /= 10;
        }
        
        return x * sum;
    }
}
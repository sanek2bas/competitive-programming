namespace Top.Interview._150.Mathematics;

public class PowXn
{
    /// <summary>
    /// # 50
    /// https://leetcode.com/problems/powx-n/description
    /// Implement pow(x, n), which calculates x raised to 
    /// the power n (i.e., xn).
    /// </summary>
    public double Execute(double x, int n)
    {
        if (n == 0)
            return 1;
        if (x == 0)
            return 0;
        if (x == 1)
            return 1;
        if (x == -1)
            return (n % 2 == 0) ? 1 : -1;

        long exponent = n;
        double result = 1.0;  
        if (exponent < 0) 
        {
            x = 1 / x;
            exponent = -exponent;
        }

        while (exponent > 0) 
        {
            if ((exponent & 1) == 1)
                result *= x;
            x *= x;
            exponent >>= 1;
        }

        return Math.Round(result, 5, MidpointRounding.AwayFromZero);
    }
}
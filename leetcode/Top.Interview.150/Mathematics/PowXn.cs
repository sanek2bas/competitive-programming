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
        if (n < 0)
        {
            x = 1/x;
            n = -n;
        }
        
        double result = 1.0;
        double curPow = x;
        while(n > 0)
        {
            if ((n % 2) == 1)
                result *= curPow;
            curPow *= curPow;
            n /= 2;
        }

        return result;
    }
}
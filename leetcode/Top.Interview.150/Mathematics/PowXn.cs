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
        if (n < 0)
            return 1 / Execute(x, -n);
        if (n % 2 == 1)
            return x * Execute(x, n-1);
        return Execute(x*x, n/2);
    }
}
namespace Top.Interview._150.Two_Pointers;

public class SqrtOfX
{
    /// <summary>
    /// # 69
    /// https://leetcode.com/problems/sqrtx/description/
    /// Given a non-negative integer x, return the square root of x rounded down to the nearest integer. 
    /// The returned integer should be non-negative as well.
    /// You must not use any built-in exponent function or operator.
    /// </summary>
    public int Execute(int x)
    {
        uint left = 1;
        uint right = (uint)x + 1;
        while (left < right)
        {
            uint middle = (left + right) / 2;
            if (middle > (x / middle))
                right = middle;
            else
                left = middle + 1;
        }
        return (int)left - 1;
    }
}

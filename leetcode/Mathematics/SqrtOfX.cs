namespace TopInterview150.Mathematics;

public static class SqrtOfX
{    
    /// <summary>
    /// Given a non-negative integer x, return the square root of x rounded down to the nearest integer. 
    /// The returned integer should be non-negative as well.
    /// You must not use any built-in exponent function or operator.
    /// </summary>
    public static int Execute(int x)
    {
        uint left = 1;
        uint right = (uint)x + 1;
        while(left < right)
        {
            uint middle = (left + right) / 2;
            if (middle > (x/middle))
                right = middle;
            else
                left = middle + 1;
        }
        return (int)left - 1;
    }

    public static IEnumerable<(int x, int answer)> GetTests()
    {
        yield return (4, 2);
        yield return (8, 2);
        yield return (2147483647, 46340);
    }

    public static bool CheckResult(int result, int answer)
    {
        return result == answer;
    }
}

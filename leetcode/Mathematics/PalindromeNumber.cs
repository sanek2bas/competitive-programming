namespace TopInterview150.Mathematics;

public static class PalindromeNumber
{
    /// <summary>
    /// Given an integer x, return true if x is a palindrome, and false otherwise.
    /// </summary>
    public static bool Execute(int x)
    {
        if (x < 0)
            return false;
        long reversed = 0;
        int y = x;
        while (y > 0) 
        {
            reversed = reversed * 10 + y % 10;
            y /= 10;
        }
        return reversed == x;
    }

    public static IEnumerable<(int x, bool answer)> GetTests()
    {
        yield return (121, true);
        yield return (-121, false);
        yield return (10, false);
    }

    public static bool CheckResult(bool result, bool answer)
    {
        return result == answer;
    }
}
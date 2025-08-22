namespace Top.Interview._150.Mathematics;

public class PalindromeNumber
{
    /// <summary>
    /// # 9
    /// https://leetcode.com/problems/palindrome-number/description/
    /// Given an integer x, return true if x is a palindrome, and false otherwise.
    /// </summary>
    public bool Execute(int x)
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
}

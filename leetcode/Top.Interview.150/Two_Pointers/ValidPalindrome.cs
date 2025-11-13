namespace Top.Interview._150.TwoPointers;

public class ValidPalindrome
{
    /// <summary>
    /// # 125
    /// https://leetcode.com/problems/valid-palindrome/description/
    /// A phrase is a palindrome if, after converting 
    /// all uppercase letters into lowercase letters and 
    /// removing all non-alphanumeric characters, 
    /// it reads the same forward and backward. 
    /// Alphanumeric characters include letters and numbers.
    /// Given a string s, return true if it is a palindrome, 
    /// or false otherwise.
    /// </summary>
    public bool Execute(string s)
    {
        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            while (left < right
                   && !char.IsLetterOrDigit(s[left]))
                left++;
            while (left < right
                   && !char.IsLetterOrDigit(s[right]))
                right--;
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;
            left++;
            right--;
        }
        return true;
    }
}
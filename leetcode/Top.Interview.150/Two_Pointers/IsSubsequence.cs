namespace Top.Interview._150.TwoPointers;

public class IsSubsequence
{
    /// <summary>
    /// # 392
    /// https://leetcode.com/problems/is-subsequence/description/
    /// Given two strings s and t, return true 
    /// if s is a subsequence of t, or false otherwise.
    /// A subsequence of a string is a new string 
    /// that is formed from the original string by deleting 
    /// some (can be none) of the characters without 
    /// disturbing the relative positions of the remaining characters. 
    /// (i.e., "ace" is a subsequence of "abcde" while "aec" is not).
    /// </summary>
    public bool Execute(string s, string t)
    {
        if (string.IsNullOrEmpty(s))
            return true;
        int i = 0;
        foreach(char ch in t)
        {
            if (s[i] == ch && ++i == s.Length)
                return true;
        }     
        return false;
    }
}
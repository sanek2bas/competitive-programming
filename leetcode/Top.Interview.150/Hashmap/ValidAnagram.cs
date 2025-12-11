namespace Top.Interview._150.HashMap;

public class ValidAnagram
{
    /// <summary>
    /// # 242
    /// https://leetcode.com/problems/valid-anagram/
    /// Given two strings s and t, return true 
    /// if t is an anagram of s, and false otherwise.
    /// An Anagram is a word or phrase formed by 
    /// rearranging the letters of a different word or phrase, 
    /// typically using all the original letters exactly once.
    /// </summary>
    public bool Execute(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        int[] letters = new int[26];
        foreach (char ch in s)
            letters[ch - 'a']++;

        foreach (char ch in t)
        {
            if (letters[ch - 'a'] == 0)
                return false;
            letters[ch - 'a']--;
        }
        return true;
    }
}
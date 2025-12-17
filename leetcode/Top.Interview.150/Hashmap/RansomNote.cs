namespace Top.Interview._150.Hashmap;

public class RansomNote
{
    /// <summary>
    /// # 383
    /// https://leetcode.com/problems/ransom-note/description/
    /// Given two strings ransomNote and magazine, 
    /// return true if ransomNote can be constructed 
    /// by using the letters from magazine and false otherwise.
    /// Each letter in magazine can only be used once in ransomNote.
    /// </summary>
    public bool Execute(string ransomNote, string magazine)
    {
        int[] chars = new int[26];
        foreach(char ch in magazine)
            chars[ch - 'a']++;
        foreach(char ch in ransomNote)
        {
            if (chars[ch - 'a'] == 0)
                return false;
            chars[ch - 'a']--;
        }
        return true;
    }
}
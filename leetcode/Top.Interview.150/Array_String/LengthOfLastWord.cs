namespace Top.Interview._150.Array_String;

public class LengthOfLastWord
{
    /// <summary>
    /// # 58
    /// https://leetcode.com/problems/length-of-last-word/description/
    /// Given a string s consisting of words and spaces, 
    /// return the length of the last word in the string.
    /// A word is a maximal substring consisting of non-space characters only.
    /// </summary>
    public int Execute(string s)
    {
        int length = 0;
        int idx = s.Length - 1;
        while (idx >= 0 && char.IsWhiteSpace(s[idx]))
            idx--;
        while (idx >= 0 && !char.IsWhiteSpace(s[idx]))
        {
            idx--;
            length++;
        }
        return length;
    }
}
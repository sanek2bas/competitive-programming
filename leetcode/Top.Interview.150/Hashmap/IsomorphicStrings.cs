namespace Top.Interview._150.Hashmap;

public class IsomorphicStrings
{
    /// <summary>
    /// # 205
    /// https://leetcode.com/problems/isomorphic-strings/description/
    /// Given two strings s and t, determine if they are isomorphic.
    /// Two strings s and t are isomorphic if the characters 
    /// in s can be replaced to get t.
    /// All occurrences of a character must be replaced with 
    /// another character while preserving 
    /// the order of characters.No two characters may map to the same character,
    ///  but a character may map to itself.
    /// </summary>
    public bool Execute(string s, string t)
    {
        var sArray = new int[128];
        var tArray = new int[128];
        for (int i = 0; i < sArray.Length; i++)
        {
            sArray[i] = -1;
            tArray[i] = -1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (sArray[s[i]] != tArray[t[i]])
                return false;
            sArray[s[i]] = i;
            tArray[t[i]] = i;
        }
        return true;
    }
}
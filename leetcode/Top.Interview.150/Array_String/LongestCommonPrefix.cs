namespace Top.Interview._150.Array_String;

public class LongestCommonPrefix
{
    /// <summary>
    /// # 14
    /// https://leetcode.com/problems/longest-common-prefix/description/
    /// Write a function to find the longest common prefix 
    /// string amongst an array of strings.
    /// If there is no common prefix, return an empty string "".
    /// </summary>
    public string Execute(string[] strs)
    {
        if (strs.Length == 0)
            return string.Empty;

        for (int charIdx = 0; charIdx < strs[0].Length; charIdx++)
        {
            for (int strIdx = 1; strIdx < strs.Length; strIdx++)
            {
                if (charIdx == strs[strIdx].Length ||
                    strs[0][charIdx] != strs[strIdx][charIdx])
                    return strs[0].Substring(0, charIdx);
            }
        }
        return strs[0];
    }
}
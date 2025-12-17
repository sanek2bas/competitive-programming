using Top.Interview._150.Two_Pointers;

public class FindIndexOfFirstOccurrenceInString
{
    /// <summary>
    /// # 28
    /// https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/description/
    /// Given two strings needle and haystack, return 
    /// the index of the first occurrence of needle in haystack, 
    /// or -1 if needle is not part of haystack.
    /// </summary>
    public int Execute(string haystack, string needle)
    {
        int haysLen = haystack.Length;
        int needLen = needle.Length;
        for (int i = 0; i <= haysLen - needLen; i++)
        {
            if (haystack.Substring(i, needLen) == needle)
                return i;
        }
        return -1;
    }
}

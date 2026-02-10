using System.Data;
using System.Text;

namespace Top.Interview._150.Multidimensional_DP;

public class LongestPalindromicSubstring
{
    /// <summary>
    /// # 5
    /// https://leetcode.com/problems/longest-palindromic-substring/description/
    /// Given a string s, return the longest palindromic substring in s.
    /// </summary>
    public string Execute(string str)
    {
        if (string.IsNullOrEmpty(str) 
            || str.Length <= 1)
            return str;
        
        char[] manacher = new char[str.Length * 2 + 1];
        manacher[0] = '#';
        for (int i = 0; i < str.Length; i++)
        {
            manacher[2 * i + 1] = str[i];
            manacher[2 * i + 2] = '#';
        }
        
        int[] radius = new int[manacher.Length];
        int center = 0, 
        right = 0;
        for (int i = 1; i < manacher.Length-1; i++)
        {
            int mirror = 2 * center - i;
            if (i < right)
                radius[i] = Math.Min(right-i, radius[mirror]);

            int a = i + radius[i] + 1;
            int b = i - radius[i] - 1;
            while (a < manacher.Length 
                && b >= 0 
                && manacher[a] == manacher[b])
            {
                radius[i]++;
                a++;
                b--;
            }

            if (i + radius[i] > right)
            {
                center = i;
                right = i + radius[i];
            }
        }

        int maxLen = 0;
        int centerIndex = 0;
        for (int i = 1; i < radius.Length - 1; i++)
        {
            if (radius[i] > maxLen)
            {
                maxLen = radius[i];
                centerIndex = i;
            }
        }

        int start = (centerIndex - maxLen) / 2;
        return str.Substring(start, maxLen);
    }
}
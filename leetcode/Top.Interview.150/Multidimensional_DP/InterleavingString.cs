namespace Top.Interview._150.Multidimensional_DP;

public class InterleavingString
{
    /// <summary>
    /// # 97
    /// https://leetcode.com/problems/interleaving-string/description/
    /// Given strings s1, s2, and s3, find whether s3 is formed by 
    /// an interleaving of s1 and s2.
    /// An interleaving of two strings s and t is a configuration 
    /// where s and t are divided 
    /// into n and m substrings respectively, such that:
    /// s = s1 + s2 + ... + sn
    /// t = t1 + t2 + ... + tm
    /// |n - m| <= 1
    /// The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... 
    /// or t1 + s1 + t2 + s2 + t3 + s3 + ...
    /// Note: a + b is the concatenation of strings a and b.
    /// </summary>
    public bool Execute(string s1, string s2, string s3)
    {
        int s1Length = s1.Length;
        int s2Length = s2.Length;
        int s3Length = s3.Length;
        if (s1Length + s2Length != s3Length)
            return false;
        
        bool[] dp = new bool[s2Length + 1];
        for(int i = 0; i <= s1Length; i++)
        {
            for(int j = 0; j <= s2Length; j++)
            {
                if (i == 0 && j == 0)
                    dp[j] = true;
                else if (i == 0)
                    dp[j] = dp[j - 1] && s2[j - 1] == s3[j - 1];
                else if (j == 0)
                    dp[j] = dp[j] && s1[i - 1] == s3[i - 1];
                else
                    dp[j] = dp[j] && s1[i - 1] == s3[i + j - 1] ||
                            dp[j - 1] && s2[j - 1] == s3[i + j - 1];
            }
        }

        return dp[s2Length];
    }
}

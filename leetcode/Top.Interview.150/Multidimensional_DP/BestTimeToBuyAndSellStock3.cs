public class BestTimeToBuyAndSellStock3
{
    /// <summary>
    /// # 123
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/description/
    /// You are given an array prices where prices[i] is the price of a
    /// given stock on the ith day.
    /// Find the maximum profit you can achieve. 
    /// You may complete at most two transactions.
    /// Note: You may not engage in multiple transactions 
    /// simultaneously (i.e., you must sell the stock before you buy again).
    /// </summary>
    public bool Execute(int[] prices)
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
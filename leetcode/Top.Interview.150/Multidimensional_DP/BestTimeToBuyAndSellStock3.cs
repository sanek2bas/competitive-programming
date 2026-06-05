namespace Top.Interview._150.Multidimensional_DP;

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
    public int Execute(int[] prices)
    {
        if (prices == null 
            || prices.Length == 0) return 0;
        
        int[][] pre = new int[2][];
        int[][] cur = new int[2][];
        
        for (int i = 0; i < 2; i++) 
        {
            pre[i] = new int[3];
            cur[i] = new int[3];
        }
        
        for (int i = prices.Length - 1; i >= 0; i--) 
        {
            for (int j = 0; j < 2; j++) 
            {
                for (int k = 0; k < 3; k++) 
                {
                    if (k == 0) 
                    {
                        cur[j][k] = 0;
                        continue;
                    }
                    
                    if (j == 1)
                        cur[1][k] = Math.Max(-prices[i] + pre[0][k], pre[1][k]);
                    else 
                        cur[0][k] = Math.Max(prices[i] + pre[1][k - 1], pre[0][k]);
                }
            }

            for (int j = 0; j < 2; j++) 
                Array.Copy(cur[j], pre[j], 3);
        }
        
        return pre[1][2];
    }
}
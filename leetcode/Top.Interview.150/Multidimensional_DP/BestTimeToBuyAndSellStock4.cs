namespace Top.Interview._150.Multidimensional_DP;

public class BestTimeToBuyAndSellStock4
{
    /// <summary>
    /// # 188
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/description/
    /// You are given an integer array prices where prices[i] is the price
    /// a given stock on the ith day, and an integer k.
    /// Find the maximum profit you can achieve. You may complete at most k 
    /// transactions: i.e. you may buy at most k times and sell at most k times.
    /// Note: You may not engage in multiple transactions simultaneously 
    /// (i.e., you must sell the stock before you buy again).
    /// </summary>
    public int Execute(int k, int[] prices)
    {
        if (prices.Length == 0 
            || k <= 0) 
            return 0;
        
        int n = prices.Length;
        
        if (k >= n / 2) 
        {
            int maxProfit = 0;
            for (int i = 1; i < n; i++) 
            {
                if (prices[i] > prices[i - 1]) 
                    maxProfit += prices[i] - prices[i - 1];
            }
            return maxProfit;
        }
        
        int[] sell = new int[k + 1];
        int[] hold = new int[k + 1];
        
        for (int i = 0; i <= k; i++) 
             hold[i] = int.MinValue;
        
        for (int day = 0; day < n; day++) 
        {
            int price = prices[day];
            for (int t = k; t >= 1; t--) 
            {
                sell[t] = Math.Max(sell[t], hold[t] + price);
                hold[t] = Math.Max(hold[t], sell[t - 1] - price);
            }
        }
        
        return sell[k];
    }
}
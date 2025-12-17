namespace Top.Interview._150.Dynamic_Programming;

public class BestTimeToBuyAndShellStock
{
    /// <summary>
    /// # 121
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
    /// You are given an array prices where prices[i] is the price 
    /// of a given stock on the ith day. You want to maximize your 
    /// profit by choosing a single day to buy one stock and 
    /// choosing a different day in the future to sell that stock. 
    /// Return the maximum profit you can achieve from this transaction.
    /// If you cannot achieve any profit, return 0.
    /// </summary>
    public int Execute(int[] prices)
    {
        var profit = 0;
        var buyPrice = prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            var price = prices[i];
            if (buyPrice > price)
            {
                buyPrice = price;
                continue;
            }

            if ((price - buyPrice) > profit)
                profit = price - buyPrice;
        }
        return profit;
    }
}
namespace TopInterview150.Array_String
{
    internal class BestTimeToBuyAndSellStockII
    {
        /// <summary>
        /// You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
        /// On each day, you may decide to buy and/or sell the stock.
        /// You can only hold at most one share of the stock at any time.
        /// However, you can buy it then immediately sell it on the same day.
        /// Find and return the maximum profit you can achieve.
        /// </summary>
        public static int Execute(int[] prices)
        {
            var profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    profit += prices[i] - prices[i - 1];
            }
            return profit;
        }

        public static IEnumerable<(int[] prices, int answer)> GetTests()
        {
            yield return (new int[] { 7, 1, 5, 3, 6, 4 }, 7);
            yield return (new int[] { 1, 2, 3, 4, 5 }, 4);
            yield return (new int[] { 7, 6, 4, 3, 1 }, 0);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

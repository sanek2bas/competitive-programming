namespace TopInterview150.Array_String
{
    public static class BestTimeToBuyAndSellStock
    {
        /// <summary>
        /// You are given an array prices where prices[i] is the price of a given stock on the ith day.
        /// You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
        /// Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.
        /// </summary>
        public static int Execute(int[] prices)
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

        public static IEnumerable<(int[] nums, int answer)> GetTests()
        {
            yield return (
                new int[] { 7, 1, 5, 3, 6, 4 },
                5);
            yield return (
                new int[] { 7, 6, 4, 3, 1 },
                0);
        }

        public static bool CheckResult(int target, int answer)
        {
            return answer == target;
        }
    }
}

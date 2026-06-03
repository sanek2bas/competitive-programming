namespace Top.Interview._150._1D_DP;

public class CoinChange
{
    /// <summary>
    /// # 322
    /// https://leetcode.com/problems/coin-change/description/
    /// You are given an integer array coins representing coins 
    /// of different denominations and an integer amount representing
    /// a total amount of money.
    /// Return the fewest number of coins that you need to 
    /// make up that amount. If that amount of money cannot be 
    /// made up by any combination of the coins, return -1.
    /// You may assume that you have an infinite number of each kind of coin.
    /// </summary>
    public int Execute(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);


        dp[0] = 0;
        for (int i = 0; i <= amount; ++i)
        {
            foreach (int coin in coins)
            {
                if (i - coin < 0) 
                    continue;
                dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
            }
        }    

        if (dp[amount] == amount + 1) 
            return -1;
        return dp[amount];
    }
}

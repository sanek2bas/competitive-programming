namespace TopInterview150._1D_DP
{
    public static class ClimbingStairs
    {
        /// <summary>
        /// You are climbing a staircase. It takes n steps to reach the top.
        /// Each time you can either climb 1 or 2 steps. 
        /// In how many distinct ways can you climb to the top?
        /// </summary>
        public static int Execute(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for(int i = 2; i <= n; i++)
                dp[i] = dp[i - 1] + dp[i - 2];
            return dp[n];
        }

        public static IEnumerable<(int n, int answer)> GetTests()
        {
            yield return (2, 2);
            yield return (3, 3);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

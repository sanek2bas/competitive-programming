namespace TopInterview150._1D_DP;

public static class HouseRobber
{
    /// <summary>
    /// You are a professional robber planning to rob houses along a street. 
    /// Each house has a certain amount of money stashed,
    /// the only constraint stopping you from robbing each of them is that adjacent houses 
    /// have security systems connected and it will automatically contact the police 
    /// if two adjacent houses were broken into on the same night.
    /// Given an integer array nums representing the amount of money of each house, 
    /// return the maximum amount of money you can rob tonight without alerting the police.
    /// </summary>
    public static int Execute(int[] nums)
    {
        int prev1 = 0; //nums[i-1]
        int prev2 = 0; //nums[i-2]
        foreach (int num in nums)
        {
            int dp = Math.Max(prev1, prev2 + num);
            prev2 = prev1;
            prev1 = dp;
        }
        return prev1;
    }

    public static IEnumerable<(int[] nums, int answer)> GetTests()
    {
        yield return (new int[] { 1, 2, 3, 1}, 4);
        yield return (new int[] { 2, 7, 9, 3, 1}, 12);
    }

    public static bool CheckResult(int result, int answer)
    {
        return result == answer;
    }
}

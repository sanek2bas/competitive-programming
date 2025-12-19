namespace Top.Interview._150._1D_DP;

public class HouseRobber
{
    /// <summary>
    /// # 198
    /// https://leetcode.com/problems/house-robber/description/
    /// You are a professional robber planning to rob houses along a street. 
    /// Each house has a certain amount of money stashed,
    /// the only constraint stopping you from robbing each 
    /// of them is that adjacent houses have security systems connected
    ///  and it will automatically contact the police 
    /// if two adjacent houses were broken into on the same night.
    /// Given an integer array nums representing the amount
    ///  of money of each house, /// return the maximum amount of money
    ///  you can rob tonight without alerting the police.
    /// </summary>
    public int Execute(int[] nums)
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
}

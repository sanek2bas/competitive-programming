namespace Top.Interview._150.Sliding_Window;

public class MinimumSizeSubarraySum
{
    /// <summary>
    /// # 209
    /// https://leetcode.com/problems/minimum-size-subarray-sum/
    /// Given an array of positive integers nums and 
    /// a positive integer target, return the minimal length 
    /// of a subarray whose sum is greater than or equal to target.
    /// If there is no such subarray, return 0 instead.
    /// </summary>
    public int Execute(int target, int[] nums)
    {
        int answer = int.MaxValue;
        int sum = 0;
        int left = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            sum += nums[right];
            while (sum >= target)
            {
                answer = Math.Min(answer, right - left + 1);
                sum -= nums[left++];
            }
        }
        return answer == int.MaxValue ? 0 : answer;
    }
}
namespace Top.Interview._150.Dynamic_Programming;

public class JumpGame2
{
    /// <summary>
    /// # 45
    /// https://leetcode.com/problems/jump-game-ii/description/
    /// You are given a 0-indexed array of integers nums of length n. 
    /// You are initially positioned at nums[0].
    /// Each element nums[i] represents the maximum length of 
    /// a forward jump from index i.In other words, 
    /// if you are at nums[i], you can jump to any nums[i + j] 
    /// where: 0 <= j <= nums[i] and i + j < n.
    /// Return the minimum number of jumps to reach nums[n - 1]. 
    /// The test cases are generated such that you can reach nums[n - 1].
    /// </summary>
    public int Execute(int[] nums)
    {
        int answer = 0;
        int end = 0;
        int farthest = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);
            if (farthest >= nums.Length - 1)
            {
                answer++;
                break;
            }
            if (i == end)
            {
                answer++;          
                end = farthest; 
            }
        }
        return answer;
    }
}
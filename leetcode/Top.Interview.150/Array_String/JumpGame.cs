namespace Top.Interview._150.Array_String;

public class JumpGame
{
    /// <summary>
    /// # 55
    /// https://leetcode.com/problems/jump-game/description/
    /// You are given an integer array nums. You are initially
    /// positioned at the array's first index, and each element 
    /// in the array represents your maximum jump length at that position.
    /// Return true if you can reach the last index, or false otherwise.
    /// </summary>
    public bool Execute(int[] nums)
    {
        int goal = nums.Length - 1;
        for(int i = nums.Length - 2; i >= 0; i--)
        {
            if (i + nums[i] >= goal)
                goal = i;
        }
        return goal == 0;
    }
}
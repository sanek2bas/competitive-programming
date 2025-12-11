namespace Top.Interview._150.Tests.TwoPointers;

public class RotateArray
{
    /// <summary>
    /// # 189
    /// https://leetcode.com/problems/rotate-array/description/
    /// Given an integer array nums, 
    /// rotate the array to the right by k steps,
    /// where k is non-negative.
    /// </summary>
    public void Execute(int[] nums, int k)
    {
        k %= nums.Length;
        Reverse(nums, 0, nums.Length - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, nums.Length - 1);
    }

    private void Reverse(int[] nums, int left, int right)
    {
        while (left < right)
        {
            var temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
            left++;
            right--;
        }
    }
}
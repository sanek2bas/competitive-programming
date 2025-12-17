namespace Top.Interview._150.Array_String;

public class ProductOfArrayExceptSelf
{
    /// <summary>
    /// # 238
    /// https://leetcode.com/problems/product-of-array-except-self/description/
    /// Given an integer array nums, return an array answer such that answer[i] 
    /// is equal to the product of all the elements of nums except nums[i].
    /// The product of any prefix or suffix of nums is guaranteed to fit 
    /// in a 32-bit integer. You must write an algorithm that runs in O(n) 
    /// time and without using the division operation.
    /// </summary>
    public int[] Execute(int[] nums)
    {
        var n = nums.Length;
        var answer = new int[n];
        var prefix = new int[n];
        var suffix = new int[n];

        prefix[0] = 1;
        for(int i = 1; i < n; i++)
            prefix[i] = prefix[i - 1] * nums[i - 1];

        suffix[n-1] = 1;
        for(int i = n-2; i >= 0; i--)
            suffix[i] = suffix[i + 1] * nums[i + 1];

        for (int i = 0; i < n; i++)
            answer[i] = prefix[i] * suffix[i];

        return answer;
    }
}
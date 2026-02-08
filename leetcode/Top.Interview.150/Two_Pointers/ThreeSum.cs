namespace Top.Interview._150.Two_Pointers;

public class ThreeSum
{
    /// <summary>
    /// # 15
    /// https://leetcode.com/problems/3sum/description/
    /// Given an integer array nums, return all the triplets 
    /// [nums[i], nums[j], nums[k]] such 
    /// that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
    /// Notice that the solution set must not contain duplicate triplets.
    /// </summary>
    public IList<IList<int>> Execute(int[] nums)
    {
        Array.Sort(nums);
        
        var result = new List<IList<int>>();
        var length = nums.Length;
        
        for (int i = 0; i < length-2; i++)
        {
            if (i > 0 && nums[i] == nums[i-1])
                continue;
            if (nums[i] > 0)
                break;

            int left = i+1;
            int right = length-1;
            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                
                if (sum < 0)
                {
                    left++;
                    continue;
                }

                if (sum > 0)
                {
                    right--;
                    continue;
                }

                result.Add([nums[i], nums[left], nums[right]]);

                while (left < right 
                    && nums[left] == nums[left+1])
                    left++;        
                
                while (left < right 
                    && nums[right] == nums[right-1])
                    right--;
                
                left++;
                right--;
            }
        }

        return result;
    }
}
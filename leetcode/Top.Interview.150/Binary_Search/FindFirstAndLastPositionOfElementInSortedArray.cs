namespace Top.Interview._150.Binary_Search;

public class FindFirstAndLastPositionOfElementInSortedArray
{
    /// <summary>
    /// # 34
    /// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
    /// Given an array of integers nums sorted in non-decreasing order, 
    /// find the starting and ending position of a given target value.
    /// If target is not found in the array, return [-1, -1].
    /// You must write an algorithm with O(log n) runtime complexity.
    /// </summary>
    public int[] Execute(int[] nums, int target)
    {
        int[] result = new int[] { -1, -1 };
        
        result[0] = FindBound(nums, target, true);
        if (result[0] != -1)
            result[1] = FindBound(nums, target, false);
        
        return result;
    }

    private int FindBound(int[] nums, int target, bool isLeft) 
    {
        int left = 0;
        int right = nums.Length - 1;
        int bound = -1;

        while (left <= right) 
        {
            int mid = left + (right - left) / 2; 

            if (nums[mid] == target) 
            {
                bound = mid;                 
                if (isLeft) 
                    right = mid - 1; 
                else 
                    left = mid + 1;
            } 
            else if (nums[mid] < target) 
            {
                left = mid + 1;
            } 
            else 
            {
                right = mid - 1;
            }
        }

        return bound;
    }
}
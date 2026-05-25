namespace Top.Interview._150.Two_Pointers;

public class TwoSum2
{
    /// <summary>
    /// # 167
    /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
    /// Given a 1-indexed array of integers numbers that is already sorted 
    /// in non-decreasing order, find two numbers such that they add up to 
    /// a specific target number. Let these two numbers be numbers[index1] 
    /// and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
    /// Return the indices of the two numbers index1 and index2, each 
    /// incremented by one, as an integer array [index1, index2] of length 2.
    /// The tests are generated such that there is exactly one solution. 
    /// You may not use the same element twice.
    /// Your solution must use only constant extra space.
    /// </summary>
    public int[] Execute(int[] numbers, int target)
    {
        for (int i = 0, n = numbers.Length;; ++i) 
        {
            int x = target - numbers[i];
            int left = i + 1, right = n - 1;
            while (left < right) 
            {
                int mid = (left + right) >> 1;
                if (numbers[mid] >= x) 
                    right = mid; 
                else
                    left = mid + 1;
            }
            
            if (numbers[left] == x) 
                return [i + 1, left + 1];
        }
    }
}
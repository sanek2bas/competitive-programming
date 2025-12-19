namespace Top.Interview._150.Binary_Search;

public class FindMinimumInRotatedSortedArray
{
    /// <summary>
    /// # 153
    /// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
    /// Suppose an array of length n sorted in ascending order 
    /// is rotated between 1 and n times. 
    /// For example, the array nums = [0,1,2,4,5,6,7] might become:
    /// [4, 5, 6, 7, 0, 1, 2] if it was rotated 4 times.
    /// [0, 1, 2, 4, 5, 6, 7] if it was rotated 7 times.
    /// Notice that rotating an array[a[0], a[1], a[2], ..., a[n - 1]] 
    /// 1 time results in 
    /// the array[a[n - 1], a[0], a[1], a[2], ..., a[n - 2]].
    /// Given the sorted rotated array nums of unique elements, 
    /// return the minimum element of this array.
    /// You must write an algorithm that runs in O(log n) time.
    /// </summary>
    public int Execute(int[] numbers)
    {
        int left = 0;
        int right = numbers.Length - 1;

        if (numbers[left] <= numbers[right])
            return numbers[left];

        while (left < right)
        {
            int mid = (left + right) / 2;
            if (numbers[0] <= numbers[mid])
                left = mid + 1;
            else
                right = mid;
        }

        return numbers[left];
    }
}
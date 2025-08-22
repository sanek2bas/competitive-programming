namespace TopInterview150.Array_String;

public static class RemoveDuplicatesFromSortedArrayII
{
    /// <summary>
    /// Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place 
    /// such that each unique element appears at most twice. The relative order of the elements should be kept the same.
    /// Since it is impossible to change the length of the array in some languages, 
    /// you must instead have the result be placed in the first part of the array nums. 
    /// More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. 
    /// It does not matter what you leave beyond the first k elements.
    /// Return k after placing the final result in the first k slots of nums.
    /// Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
    /// </summary>
    public static int Execute(int[] nums)
    {
        int i = 0;
        foreach(int num in nums)
        {
            if (i < 2 || num > nums[i - 2])
                nums[i++] = num;
        }
        return i;
    }

    public static IEnumerable<(int[] nums, int[] answer)> GetTests()
    {
        yield return (new int[] { 1, 1, 1, 2, 2, 3 }, 
                      new int[] { 1, 1, 2, 2, 3 });
        yield return (new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 }, 
                      new int[] { 0, 0, 1, 1, 2, 3, 3 });
    }

    public static bool CheckResult(int[] resultNums, int result, int[] answer)
    {
        return resultNums.Take(result)
                         .SequenceEqual(answer);
    }
}

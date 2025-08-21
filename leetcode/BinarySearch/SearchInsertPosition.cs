namespace TopInterview150.BinarySearchTree;

public static class SearchInsertPosition
{
    /// <summary>
    /// Given a sorted array of distinct integers and a target value, return the index if the target is found.
    /// If not, return the index where it would be if it were inserted in order.
    /// You must write an algorithm with O(log n) runtime complexity.
    /// </summary>
    public static int Execute(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length;
        while (left < right)
        {
            int middle = (left + right) / 2;
            if (nums[middle] == target)
                return middle;
            if (nums[middle] < target)
                left = middle + 1;
            else
                right = middle;
        }
        return left;
    }

    public static IEnumerable<(int[] nums, int target, int answer)> GetTests()
    {
        yield return (new int[] { 1,3,5,6 }, 5, 2);
        yield return (new int[] { 1,3,5,6 }, 2, 1);
        yield return (new int[] { 1,3,5,6 }, 7, 4);
    }

    public static bool CheckResult(int result, int answer)
    {
        return result == answer;
    }
}

namespace TopInterview150.Intervals;

public static class SummaryRanges
{
    /// <summary>
    /// You are given a sorted unique integer array nums.
    /// A range [a,b] is the set of all integers from a to b (inclusive).
    /// Return the smallest sorted list of ranges that cover all the numbers in the array exactly.
    /// That is, each element of nums is covered by exactly one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.
    /// </summary>
    public static IList<string> Execute(int[] nums)
    {
        var answer = new List<string>();
        for(int i = 0; i < nums.Length; i++)
        {
            var start = nums[i];
            while(i + 1 < nums.Length && nums[i] == nums[i+1] - 1)
                  i++;
            int end = nums[i];
            if (start == end)
                answer.Add(start.ToString());
            else
                answer.Add($"{start}->{end}");
        }
        return answer;
    }

    public static IEnumerable<(int[] nums, IList<string> answer)> GetTests()
    {
        yield return (new int[] { 0, 1, 2, 4, 5, 7 }, 
                      new List<string> { "0->2", "4->5", "7" });
        yield return (new int[] { 0, 2, 3, 4, 6, 8, 9 }, 
                      new List<string> { "0", "2->4", "6", "8->9" });
    }

    public static bool CheckResult(IList<string> result, IList<string> answer)
    {
        return answer.SequenceEqual(result);
    }
}

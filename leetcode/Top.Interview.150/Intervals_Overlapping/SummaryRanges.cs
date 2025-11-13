namespace Top.Interview._150.Intervals;

public class SummaryRanges
{
    /// <summary>
    /// # 228
    /// https://leetcode.com/problems/summary-ranges/description/
    /// You are given a sorted unique integer array nums.
    /// A range [a,b] is the set of all integers from a to b (inclusive).
    /// Return the smallest sorted list of ranges 
    /// that cover all the numbers in the array exactly.
    /// That is, each element of nums is covered by exactly 
    /// one of the ranges, and there is no integer 
    /// x such that x is in one of the ranges but not in nums.
    /// </summary>
    public IList<string> Execute(int[] nums)
    {
        var answer = new List<string>();
        for (int i = 0; i < nums.Length; i++)
        {
            var start = nums[i];
            while (i + 1 < nums.Length 
                   && nums[i] == nums[i + 1] - 1)
            {
                i++;
            }
            int end = nums[i];
            if (start == end)
                answer.Add(start.ToString());
            else
                answer.Add($"{start}->{end}");
        }
        return answer;
    }
}

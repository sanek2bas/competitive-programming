namespace Top.Interview._150.Intervals;

public class MergeIntervals
{
    /// <summary>
    /// # 56
    /// https://leetcode.com/problems/merge-intervals/
    /// Given an array of intervals where 
    /// intervals[i] = [starti, endi], merge all overlapping intervals, 
    /// and return an array of the non-overlapping intervals 
    /// that cover all the intervals in the input.
    /// </summary>
    public int[][] Execute(int[][] intervals)
    {
        intervals = intervals.OrderBy(i => i[0])
                             .ToArray();

        var result = new List<int[]>();
        result.Add(intervals[0]);

        foreach (int[] interval in intervals)
        {
            var lastInResult = result.Last();
            if (lastInResult[1] >= interval[0])
                lastInResult[1] = Math.Max(lastInResult[1], interval[1]);
            else
                result.Add(interval);
        }

        return result.ToArray();
    }
}
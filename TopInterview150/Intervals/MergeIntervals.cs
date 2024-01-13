namespace TopInterview150.Intervals
{
    public static class MergeIntervals
    {
        /// <summary>
        /// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, 
        /// and return an array of the non-overlapping intervals that cover all the intervals in the input.
        /// </summary>
        public static int[][] Execute(int[][] intervals)
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

        public static IEnumerable<(int[][] intervals, int[][] answer)> GetTests()
        {
            yield return (
                new int[][]
                {
                    new int[] { 1, 3 },
                    new int[] { 2, 6 },
                    new int[] { 8, 10 },
                    new int[] { 15, 18 }
                },
                new int[][]
                {
                    new int[] { 1, 6 },
                    new int[] { 8, 10 },
                    new int[] { 15, 18 }
                });
            yield return (
                new int[][]
                {
                    new int[] { 1, 4 },
                    new int[] { 4, 5 }
                },
                new int[][]
                {
                    new int[] { 1, 5 }
                });
        }

        public static bool CheckResult(int[][] target, int[][] answer)
        {
            if(answer.Length != target.Length)
                return false;
            for(int i = 0; i < answer.Length; i++) 
            {
                if (answer[i].Length != target[i].Length ||
                    !answer[i].SequenceEqual(target[i]))
                    return false;
            }
            return true;
        }
    }
}

namespace Interview.Sort
{
    public static class MergeIntervals
    {
        /// <summary>
        /// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, 
        /// and return an array of the non-overlapping intervals that cover all the intervals in the input.
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static int[][] Execute(int[][] intervals)
        {
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            
            var result = new List<int[]>();
            result.Add(intervals[0]);

            foreach (int[] interval in intervals)
            {
                var lastResultInterval = result.Last();
                if (lastResultInterval[1] >= interval[0])
                    lastResultInterval[1] = Math.Max(lastResultInterval[1], interval[1]);
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
                    new int[] {1, 3},
                    new int[] {2, 6},
                    new int[] {8, 10},
                    new int[] {15, 18}
                },
                new int[][]
                {
                    new int[] {1, 6},
                    new int[] {8, 10},
                    new int[] {15, 18}
                });
            yield return (
                new int[][]
                {
                    new int[] {1, 4},
                    new int[] {4, 5},
                },
                new int[][]
                {
                    new int[] {1, 5}
                });
        }

        public static bool CheckResult(int[][] result, int[][] answer)
        {
            if(result == answer)
                return true;

            if (result.Length != answer.Length ||
                result[0].Length != answer[0].Length)
                return false;

            for (int i = 0; i < answer.Length; i++)
            {
                for (int j = 0; j < answer[0].Length; j++)
                {
                    if (answer[i][j] != result[i][j])
                        return false;
                }
            }

            return true;
        }
    }
}

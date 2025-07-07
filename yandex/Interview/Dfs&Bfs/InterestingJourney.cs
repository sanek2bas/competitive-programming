namespace Interview.Dfs_Bfs
{
    public class InterestingJourney
    {
        /// <summary>
        /// </summary>
        public static int Execute(IList<int[]> cities, int distance, int start, int finish)
        {
            if(start == finish)
                return 0;

            var startIdx = start - 1;
            var finishIdx = finish - 1;

            var visited = new HashSet<int>();
            visited.Add(startIdx);
            var queue = new Queue<(int idx, int count)>();
            queue.Enqueue((startIdx, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.idx == finishIdx)
                    return current.count;

                for(int idx = 0; idx < cities.Count; idx++)
                {
                    if (visited.Contains(idx))
                        continue;
                    if (GetDistanceBetween(cities[current.idx], cities[idx]) > distance)
                        continue;
                    visited.Add(idx);
                    queue.Enqueue((idx, current.count + 1));
                }
            }

            return -1;
        }

        private static int GetDistanceBetween(int[] a, int[] b)
        {
            int x1 = a[0];
            int x2 = b[0];
            int y1 = a[1];
            int y2 = b[1];

            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        public static IEnumerable<(IList<int[]> cites, int distance, int start, int end, int answer)> GetTests()
        {
            yield return (
                new List<int[]>
                {
                    new int[] { 0, 0 },
                    new int[] { 0, 2 },
                    new int[] { 2, 2 },
                    new int[] { 0, -2 },
                    new int[] { 2, -2 },
                    new int[] { 2, -1 },
                    new int[] { 2, 1 }
                }, 2, 1, 3, 2);

            yield return (
               new List<int[]>
               {
                    new int[] { 0, 0 },
                    new int[] { 1, 0 },
                    new int[] { 0, 1 },
                    new int[] { 1, 1}
               }, 2, 1, 4, 1);

            yield return (
              new List<int[]>
              {
                    new int[] { 0, 0 },
                    new int[] { 2, 0 },
                    new int[] { 0, 2 },
                    new int[] { 2, 2}
              }, 1, 1, 4, -1);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}
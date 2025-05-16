namespace TopInterview150.Backtracking
{
    public static class Combinations
    {
        /// <summary>
        /// Given two integers n and k, return all possible combinations of k numbers chosen from the range [1, n].
        /// You may return the answer in any order.
        /// </summary>
        public static IList<IList<int>> Execute(int n, int k)
        {
            var result = new List<IList<int>>();
            DFS(n, k, 1, new List<int>(), result);
            return result;
        }

        private static void DFS(int n, int k, int s, List<int> path, List<IList<int>> result)
        {
            if (path.Count == k)
            {
                result.Add(path.ToList());
                return;
            }

            for (int i = s; i <= n; ++i)
            {
                path.Add(i);
                DFS(n, k, i + 1, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }

        public static IEnumerable<(int n, int k, IList<IList<int>> answer)> GetTests()
        {
            yield return (4, 2,
                new List<IList<int>>
                {
                    new List<int> { 1, 2 },
                    new List<int> { 1, 3 },
                    new List<int> { 1, 4 },
                    new List<int> { 2, 3 },
                    new List<int> { 2, 4 },
                    new List<int> { 3, 4 }
                });
            yield return (1, 1, new List<IList<int>> { new List<int> { 1 } });
        }

        public static bool CheckResult(IList<IList<int>> result, IList<IList<int>> answer)
        {
            if(result.Count != answer.Count)
                return false;
            for(int i = 0; i < result.Count; i++) 
            {
                if (!result[i].SequenceEqual(answer[i]))
                    return false;
            }
            return true;
        }
    }
}

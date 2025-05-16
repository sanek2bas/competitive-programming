using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150.Backtracking
{
    public static class Permutations
    {
        /// <summary>
        /// Given an array nums of distinct integers, return all the possible permutations.
        /// You can return the answer in any order.
        /// </summary>
        public static IList<IList<int>> Execute(int[] nums)
        {
            var result = new List<IList<int>>();
            DFS(nums, new bool[nums.Length], new List<int>(), result);
            return result;
        }

        private static void DFS(int[] nums, bool[] used, IList<int> path, IList<IList<int>> result)
        {
            if (nums.Length == path.Count)
            {
                result.Add(new List<int>(path));
                return;
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;
                used[i] = true;
                path.Add(nums[i]);
                DFS(nums, used, path, result);
                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }

        public static IEnumerable<(int[] nums, IList<IList<int>> answer)> GetTests()
        {
            yield return (
                new int[] { 1, 2, 3 },
                new List<IList<int>>()
                {
                    new List<int> { 1, 2, 3 },
                    new List<int> { 1, 3, 2 },
                    new List<int> { 2, 1, 3 },
                    new List<int> { 2, 3, 1 },
                    new List<int> { 3, 1, 2 },
                    new List<int> { 3, 2, 1 }
                });
            yield return (
                new int[] { 0, 1 },
                new List<IList<int>>()
                {
                    new List<int> { 0, 1 },
                    new List<int> { 1, 0 }
                });
            yield return (
                new int[] { 1 },
                new List<IList<int>>()
                {
                    new List<int> { 1 }
                });
        }

        public static bool CheckResult(IList<IList<int>> result, IList<IList<int>> answer)
        {
            if (result.Count != answer.Count)
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

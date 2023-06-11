using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Heap_Hash
{
    public static class TopKFrequentElements
    {
        /// <summary>
        /// Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] Execute(int[] nums, int k)
        {
            var dic = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (dic.ContainsKey(num))
                    dic[num]++;
                else
                    dic.Add(num, 1);
            }

            var orderedDic = dic.OrderByDescending(x => x.Value).ToList();
            var result = new List<int>();
            for (int i = 0; i < k; i++)
                result.Add(orderedDic[i].Key);

            return result.ToArray();
        }

        public static IEnumerable<(int[] nums, int k, int[] answer)> GetTests()
        {
            yield return (new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] { 1, 2 });
            yield return (new int[] { 1 }, 1, new int[] { 1 });
        }

        public static bool CheckResult(int[] result, int[] answer)
        {
            if (result == answer)
                return true;

            if (result.Length != answer.Length)
                return false;

            for (int i = 0; i < result.Length; i++)
            {
                if (!answer.Contains(result[i]))
                    return false;
            }

            return true;
        }
    }
}

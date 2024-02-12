using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route256.Contest
{
    public static class KSaw
    {
        public static IList<int> Execute(IList<int> prices)
        {
            var st = new StringBuilder();
            var cur = prices.First();
            for (int i = 1; i < prices.Count; i++)
            {
                st.Append(cur < prices[i] ? '<' : '>');
                cur = prices[i];
            }

            var start = 0;
            var end = st.Length-1;
            var first = -1;
            var last = -1;
            var max = -1;


            var result = new List<int>();
            return result;
        }

        public static IEnumerable<(IList<int> prices, IList<int> answer)> GetTests()
        {
            yield return (
                new int[] { 2, 3, 4, 5, 4, 3, 2, 1 }, 
                new int[] { 1, 1, 1, 0, 0, 0, 0, 0 });
            yield return (
                new int[] { 99, 99, 99, 99 },
                new int[] { 0, 0, 0, 0 });
            yield return (
                new int[] { 123456789 },
                new int[] { 0 });
            yield return (
                new int[] { 1, 3, 10, 8, 7, 4, 6, 5, 11, 3, 9, 2 },
                new int[] { 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            yield return (
                new int[] { 100, 99, 98, 1000 },
                new int[] { 0, 0, 0, 0 });
        }

        public static bool CheckResult(IList<int> result, IList<int> answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}

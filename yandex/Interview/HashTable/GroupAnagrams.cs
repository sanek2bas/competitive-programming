namespace Interview.HashTable
{
    public static class GroupAnagrams
    {
        public static IList<IList<string>> Execute(string[] strs)
        {
            var dic = new Dictionary<string, List<string>>();
            foreach (var str in strs) 
            {
                var chars = str.ToArray();
                Array.Sort(chars);
                var oredredStr = new string(chars);
                if (dic.ContainsKey(oredredStr))
                    dic[oredredStr].Add(str);
                else
                    dic.Add(oredredStr, new List<string> { str });
            }

            var result = new List<IList<string>>();
            foreach (var value in dic.Values)
                result.Add(value);

            return result;
        }

        public static IEnumerable<(string[] strs, IList<IList<string>> answer)> GetTests()
        {
            yield return (
                new string[] {"eat", "tea", "tan", "ate", "nat", "bat"},
                new List<IList<string>>
                {
                    new List<string> {"bat"},
                    new List<string> {"nat", "tan"},
                    new List<string> {"ate", "eat", "tea"}
                });
            yield return (
                new string[] {},
                new List<IList<string>> {});
            yield return (
                new string[] {"a"},
                new List<IList<string>> 
                {
                    new List<string> {"a"}
                });
        }

        public static bool CheckResult(IList<IList<string>> result, IList<IList<string>> answer)
        {
            foreach (var listResult in result)
            {
                IList<string> matchListAnswer = null;
                foreach (var answerResult in answer)
                {
                    if(answerResult.All(listResult.Contains))
                    {
                        matchListAnswer = answerResult;
                        break;
                    }
                }
                if (matchListAnswer == null)
                    return false;
                answer.Remove(matchListAnswer);
            }

            return answer.Count == 0;
        }
    }
}

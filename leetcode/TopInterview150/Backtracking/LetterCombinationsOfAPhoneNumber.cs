using System.Text;

namespace TopInterview150.Backtracking
{
    public static class LetterCombinationsOfAPhoneNumber
    {
        /// <summary>
        /// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
        /// Return the answer in any order.
        /// A mapping of digits to letters(just like on the telephone buttons) is given below.Note that 1 does not map to any letters.
        /// </summary>
        public static IList<string> Execute(string digits)
        {
            var dic = new string[] {
                "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            var result = new List<string>();
            dfs(digits, 0, dic, result, new StringBuilder());
            return result;
        }

        private static void dfs(string digits, int idx, string[] dic, List<string> results, StringBuilder result)
        {
            if (idx == digits.Length)
            {
                if (result.Length > 0)
                    results.Add(result.ToString());
                return;
            }

            foreach(var ch in dic[(int)char.GetNumericValue(digits[idx])])
            {
                result.Append(ch);
                dfs(digits, idx + 1, dic, results, result);
                result.Remove(result.Length - 1, 1);
            }
        }

        public static IEnumerable<(string digits, IList<string> answer)> GetTests()
        {
            yield return (
                "23",
                new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" });
            yield return (
                "",
                new string[] { });
            yield return (
                "2",
                new string[] { "a", "b", "c" });
        }

        public static bool CheckResult(IList<string> result, IList<string> answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}

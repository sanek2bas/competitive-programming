namespace Interview.DynamicProgramming
{
    public static class GenerateParentheses
    {
        /// <summary>
        /// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<string> Execute(int n)
        {
            var result = new List<string>();
            Generate(result, string.Empty, n, 0, 0);
            return result;
        }

        private static void Generate(IList<string> result, string str, int n, int left, int right)
        {
            if (left == n
                && right == n)
            {
                result.Add(str);
                return;
            }

            if (left < n)
                Generate(result, str + "(", n, left + 1, right);

            if (right < left)
                Generate(result, str + ")", n, left, right + 1);
        }

        public static IEnumerable<(int n, IList<string> answer)> GetTests()
        {
            
        }

        public static bool CheckResult(IList<string> result, IList<string> answer)
        {
            if (result.Count != answer.Count)
                return false;

            if (!result.SequenceEqual(answer))
                return false;

            return true;
        }
    }
}

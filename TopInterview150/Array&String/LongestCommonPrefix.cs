namespace TopInterview150.Array_String
{
    public static class LongestCommonPrefix
    {
        /// <summary>
        /// Write a function to find the longest common prefix string amongst an array of strings.
        /// If there is no common prefix, return an empty string "".
        /// </summary>
        public static string Execute(string[] strs)
        {
            if (strs.Length == 0)
                return string.Empty;

            for (int charIdx = 0; charIdx < strs[0].Length; charIdx++)
            {
                for (int strIdx = 1; strIdx < strs.Length; strIdx++)
                {
                    if (charIdx == strs[strIdx].Length ||
                        strs[0][charIdx] != strs[strIdx][charIdx])
                        return strs[0].Substring(0, charIdx);
                }
            }
            return strs[0];
        }

        public static IEnumerable<(string[] strs, string answer)> GetTests()
        {
            yield return (
                new string[] { "flower", "flow", "flight" },
                "fl");
            yield return (
                new string[] { "dog", "racecar", "car" },
                "");
        }

        public static bool CheckResult(string target, string answer)
        {
            return answer == target;
        }
    }
}

namespace TopInterview150.Array_String
{
    public static class FindIndexOfFirstOccurrenceInString
    {
        /// <summary>
        /// Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, 
        /// or -1 if needle is not part of haystack.
        /// </summary>
        public static int Execute(string haystack, string needle)
        {
            int haysLen = haystack.Length;
            int needLen = needle.Length;
            for (int i = 0; i <= haysLen - needLen; i++)
            {
                if (haystack.Substring(i, needLen) == needle)
                    return i;
            }
            return -1;
        }

        public static IEnumerable<(string haystack, string needle, int answer)> GetTests()
        {
            yield return (
                "sadbutsad",
                "sad",
                0);
            yield return (
                "leetcode", 
                "leeto",
                -1);
        }

        public static bool CheckResult(int target, int answer)
        {
            return answer == target;
        }
    }
}

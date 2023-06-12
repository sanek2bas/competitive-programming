namespace Interview.SlidingWindow
{
    public static class LongestRepeatingCharacterReplacement

    {
        /// <summary>
        /// You are given a string s and an integer k. 
        /// You can choose any character of the string and change it to any other uppercase English character. 
        /// You can perform this operation at most k times.
        /// Return the length of the longest substring containing the same letter you can get after performing the above operations.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int Execute(string s, int k)
        {
            int[] count = new int[26];
            int maxCount = 0;
            int maxLength = 0;

            int left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                var windowRightChar = s[right];
                count[windowRightChar - 'A'] += 1;
                maxCount = Math.Max(maxCount, count[windowRightChar - 'A']);

                while (right - left + 1 - maxCount > k)
                {
                    var windowLeftChar = s[left];
                    count[windowLeftChar - 'A'] -= 1;
                    left++;
                }

                maxLength = Math.Max(maxLength, right - left + 1);
            }
            return maxLength;
        }

        public static IEnumerable<(string s, int k, int answer)> GetTests()
        {
            yield return ("ABAB", 2, 4);
            yield return ("AABABBA", 1, 4);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

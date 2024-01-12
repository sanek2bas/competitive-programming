namespace TopInterview150.Hashmap
{
    public static class RansomNote
    {
        /// <summary>
        /// Given two strings ransomNote and magazine, return true if ransomNote can be constructed 
        /// by using the letters from magazine and false otherwise.
        /// Each letter in magazine can only be used once in ransomNote.
        /// </summary>
        public static bool Execute(string ransomNote, string magazine)
        {
            int[] chars = new int[26];
            foreach(char ch in magazine)
                chars[ch - 'a']++;
            foreach(char ch in ransomNote)
            {
                if (chars[ch - 'a'] == 0)
                    return false;
                chars[ch - 'a']--;
            }
            return true;
        }

        public static IEnumerable<(string ransomNote, string magazine, bool answer)> GetTests()
        {
            yield return ("a", "b", false);
            yield return ("aa", "ab", false);
            yield return ("aa", "aab", true);

        }

        public static bool CheckResult(bool target, bool answer)
        {
            return answer == target;
        }
    }
}

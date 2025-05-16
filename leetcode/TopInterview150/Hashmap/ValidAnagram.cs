namespace TopInterview150.Hashmap
{
    public static class ValidAnagram
    {
        /// <summary>
        /// Given two strings s and t, return true if t is an anagram of s, and false otherwise.
        /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
        /// typically using all the original letters exactly once.
        /// </summary>
        public static bool Execute(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            int[] letters = new int[26];
            foreach (char ch in s)
                letters[ch - 'a']++;
            
            foreach(char ch in t)
            {
                if (letters[ch - 'a'] == 0)
                    return false;
                letters[ch - 'a']--;
            }
            return true;
        }

        public static IEnumerable<(string s, string t, bool answer)> GetTests()
        {
            yield return ("anagram", "nagaram", true);
            yield return ("rat", "car", false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return answer == result;
        }
    }
}

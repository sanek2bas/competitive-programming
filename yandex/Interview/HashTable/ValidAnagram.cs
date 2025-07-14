namespace Interview.HashTable
{
    public class ValidAnagram
    {
        /// <summary>
        /// Given two strings s and t, return true if t is an anagram of s, 
        /// and false otherwise.
        /// </summary>
        public static bool Execute(string s, string r)
        {
            var alphabet = new char[26];

            if (s.Length != r.Length)
                return false;

            foreach (char c in s.ToLower())
                alphabet[c - 'a']++;

            foreach (char c in r.ToLower())
            {
                if (alphabet[c - 'a'] == 0)
                    return false;
                alphabet[c - 'a']--;
            }

            return true;
        }

        public static IEnumerable<(string s, string t, bool answer)> GetTests()
        {
            yield return ("anagram", "nagaram", true);
            yield return ("rat", "cat", false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}
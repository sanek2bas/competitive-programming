namespace TopInterview150.Hashmap
{
    public static class WordPattern
    {
        /// <summary>
        /// Given a pattern and a string s, find if s follows the same pattern.
        /// Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.
        /// </summary>
        public static bool Execute(string pattern, string s)
        {
            string[] words = s.Split(' ').ToArray();
            if (words.Length != pattern.Length)
                return false;

            var wordsDic = new Dictionary<string, int>();
            var patternDic = new Dictionary<char, int>();
            for (int i = 0; i < words.Length; i++) 
            {
                var word = words[i];
                var ch = pattern[i];
                if (!wordsDic.ContainsKey(word))
                    wordsDic.Add(word, -1);
                if (!patternDic.ContainsKey(ch))
                    patternDic.Add(ch, -1);
                if (wordsDic[word] != patternDic[ch])
                    return false;
                wordsDic[word] = i;
                patternDic[ch] = i;
            }
            return true;
        }

        public static IEnumerable<(string pattern, string str, bool answer)> GetTests()
        {
            yield return ("abba", "dog cat cat dog", true);
            yield return ("abba", "dog cat cat fish", false);
            yield return ("aaaa", "dog cat cat dog", false);

        }

        public static bool CheckResult(bool target, bool answer)
        {
            return answer == target;
        }
    }
}

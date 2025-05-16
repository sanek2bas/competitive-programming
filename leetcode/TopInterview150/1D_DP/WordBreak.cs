namespace TopInterview150._1D_DP;

public static class WordBreak
{
    /// <summary>
    /// Given a string s and a dictionary of strings wordDict, return true 
    /// if s can be segmented into a space-separated sequence of one or more dictionary words.
    /// Note that the same word in the dictionary may be reused multiple times in the segmentation.
    /// </summary>
    public static bool Execute(string s, IList<string> words)
    {
        return Break(s, new HashSet<string>(words), new Dictionary<string, bool>());
    }

    private static bool Break(string s, HashSet<string> wordsSet, Dictionary<string, bool> wordsDic)
    {
        if (wordsDic.ContainsKey(s))
            return wordsDic[s];
        if(wordsSet.Contains(s))
        {
            wordsDic.Add(s, true);
            return true;
        }

        for(int i = 1; i < s.Length; i++)
        {
            string prefix = s.Substring(0, i);
            string suffix = s.Substring(i);
            if (wordsSet.Contains(prefix) && Break(suffix, wordsSet, wordsDic))
            {
                wordsDic.Add(s, true);
                return true;
            }
        }

        wordsDic.Add(s, false);
        return false;
    }

    public static IEnumerable<(string s, IList<string> words, bool answer)> GetTests()
    {
        yield return (
            "leetcode",
            new List<string>() {"leet", "code"}, 
            true);
        yield return (
            "applepenapple",
            new List<string>() {"apple", "pen"}, 
            true);
        yield return (
            "catsandog",
            new List<string>() {"cats", "dog", "sand", "and", "cat"}, 
            false);
    }

    public static bool CheckResult(bool result, bool answer)
    {
        return result == answer;
    }

}

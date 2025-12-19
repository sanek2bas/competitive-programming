namespace Top.Interview._150._1D_DP;

public class WordBreak
{
    /// <summary>
    /// # 139
    /// https://leetcode.com/problems/word-break/description/
    /// Given a string s and a dictionary of strings wordDict, 
    /// return true if s can be segmented into a space-separated sequence 
    /// of one or more dictionary words. Note that the same word 
    /// in the dictionary may be reused multiple times in the segmentation.
    /// </summary>
    public bool Execute(string s, IList<string> words)
    {
        return Break(
            s, 
            new HashSet<string>(words), 
            new Dictionary<string, bool>());
    }

    private bool Break(string s, HashSet<string> wordsSet, Dictionary<string, bool> wordsDic)
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
}

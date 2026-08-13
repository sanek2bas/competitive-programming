namespace Top.Interview._150.Sliding_Window;

public class SubstringWithConcatenationOfAllWords
{
    /// <summary>
    /// # 30
    /// https://leetcode.com/problems/substring-with-concatenation-of-all-words/description/
    /// You are given a string s and an array of strings words. 
    /// All the strings of words are of the same length.
    /// A concatenated string is a string that exactly contains all the strings 
    /// of any permutation of words concatenated.
    /// For example, if words = ["ab","cd","ef"], 
    /// then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" 
    /// are all concatenated strings. "acdbef" is not a concatenated string 
    /// because it is not the concatenation of any permutation of words.
    /// Return an array of the starting indices of all the concatenated 
    /// substrings in s. You can return the answer in any order.
    /// </summary>
    public IList<int> Execute(string s, string[] words)
    {
        var wordCount = new Dictionary<string, int>();
        foreach (string word in words) {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }
        
        List<int> result = new List<int>();
        int stringLength = s.Length;
        int wordArrayLength = words.Length;
        int wordLength = words[0].Length;
        
        for (int startPos = 0; startPos < wordLength; startPos++) 
        {
            int left = startPos;
            int right = startPos;
            var currentWindowCount = new Dictionary<string, int>();
            
            while (right + wordLength <= stringLength) 
            {
                string currentWord = s.Substring(right, wordLength);
                right += wordLength;
                
                if (!wordCount.ContainsKey(currentWord)) 
                {
                    currentWindowCount.Clear();
                    left = right;
                    continue;
                }
                
                if (currentWindowCount.ContainsKey(currentWord))
                    currentWindowCount[currentWord]++;
                else
                    currentWindowCount[currentWord] = 1;
                
                while (currentWindowCount[currentWord] > wordCount[currentWord]) 
                {
                    string leftWord = s.Substring(left, wordLength);
                    
                    if (currentWindowCount.ContainsKey(leftWord)) 
                    {
                        currentWindowCount[leftWord]--;
                        if (currentWindowCount[leftWord] == 0) {
                            currentWindowCount.Remove(leftWord);
                        }
                    }
                    
                    left += wordLength;
                }
                
                if (right - left == wordArrayLength * wordLength) 
                    result.Add(left);
            }
        }
        
        return result;
    }
}
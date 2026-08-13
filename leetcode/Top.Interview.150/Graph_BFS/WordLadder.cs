namespace Top.Interview._150.Graph_BFS;

public class WordLadder
{
    /// <summary>
    /// # 127
    /// https://leetcode.com/problems/word-ladder/description/
    /// A transformation sequence from word beginWord to word 
    /// endWord using a dictionary wordList is a sequence of 
    /// words beginWord -> s1 -> s2 -> ... -> sk such that:
    /// Every adjacent pair of words differs by a single letter.
    /// Every si for 1 <= i <= k is in wordList. Note that beginWord 
    /// does not need to be in wordList.
    /// sk == endWord
    /// Given two words, beginWord and endWord, and a dictionary wordList, 
    /// return the number of words in the shortest transformation sequence 
    /// from beginWord to endWord, or 0 if no such sequence exists.
    /// </summary>
    public int Execute(string beginWord, string endWord, IList<string> wordList)
    {
        var words = new HashSet<string>(wordList);
        
        if (!words.Contains(endWord))
            return 0;

        Queue<(string word, int level)> queue = new Queue<(string, int)>();
        queue.Enqueue((beginWord, 1));

        HashSet<string> visited = new HashSet<string>();
        visited.Add(beginWord);

        while (queue.Count > 0) 
        {
            var current = queue.Dequeue();
            string currentWord = current.word;
            int currentLevel = current.level;

            if (currentWord == endWord)
                return currentLevel;

            char[] wordArray = currentWord.ToCharArray();
            for (int i = 0; i < wordArray.Length; i++) 
            {
                char originalChar = wordArray[i];

                for (char c = 'a'; c <= 'z'; c++) 
                {
                    if (c == originalChar) 
                        continue;

                    wordArray[i] = c;
                    string nextWord = new string(wordArray);

                    if (words.Contains(nextWord) && !visited.Contains(nextWord)) 
                    {
                        visited.Add(nextWord);
                        queue.Enqueue((nextWord, currentLevel + 1));
                    }
                }
                
                wordArray[i] = originalChar;
            }
        }
        
        return 0;
    }
}
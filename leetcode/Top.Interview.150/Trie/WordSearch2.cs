using Top.Interview._150.Common;

namespace Top.Interview._150.Trie;

public class WordSearch2
{
    /// <summary>
    /// # 212
    /// https://leetcode.com/problems/implement-trie-prefix-tree/description/
    /// Given an m x n board of characters and a list of strings words, return 
    /// all words on the board.
    /// Each word must be constructed from letters of sequentially adjacent cells,
    /// where adjacent cells are horizontally or vertically neighboring. 
    /// The same letter cell may not be used more than once in a word.
    /// </summary>
    public IList<string> Execute(char[][] board, string[] words)
    {
        int ROWS = board.Length;
        int COLS = board[0].Length;
        List<string> res = new List<string>();

        foreach (string word in words) 
        {
            bool flag = false;
            for (int r = 0; r < ROWS && !flag; r++) 
            {
                for (int c = 0; c < COLS; c++) 
                {
                    if (board[r][c] != word[0]) 
                        continue;
                    if (Backtrack(board, r, c, word, 0)) {
                        res.Add(word);
                        flag = true;
                        break;
                    }
                }
            }
        }
        return res;
    }

    private bool Backtrack(char[][] board, int r, int c, string word, int i) 
    {
        if (i == word.Length) 
            return true;
        
        if (r < 0 
            || c < 0 
            || r >= board.Length 
            || c >= board[0].Length 
            || board[r][c] != word[i])
            return false;

        board[r][c] = '*';
        bool ret = 
            Backtrack(board, r + 1, c, word, i + 1) 
            || Backtrack(board, r - 1, c, word, i + 1) 
            || Backtrack(board, r, c + 1, word, i + 1) 
            || Backtrack(board, r, c - 1, word, i + 1);
        board[r][c] = word[i];
        return ret;
    }
}
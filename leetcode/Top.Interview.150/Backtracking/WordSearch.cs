namespace Top.Interview._150.Backtracking;

public class WordSearch
{
    /// <summary>
    /// # 79
    /// https://leetcode.com/problems/word-search/description/
    /// Given an m x n grid of characters board and a string word, return true 
    /// if word exists in the grid. The word can be constructed from letters 
    /// of sequentially adjacent cells, where adjacent cells are horizontally 
    /// or vertically neighboring. The same letter cell may not be used more 
    /// than once.
    /// </summary>
    public bool Execute(char[][] board, string word)
    {
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                if (DFS(board, word, row, col, 0))
                    return true;
            }
        }
        return false;
    }

    private bool DFS(
        char[][] board, string word, int row, int col, int idx)
    {
        if (row < 0 
            || row == board.Length 
            || col < 0 
            || col == board[0].Length)
            return false;
        
        if (board[row][col] != word[idx]
            || board[row][col] == '*')
            return false;
        
        if (idx == word.Length - 1)
            return true;
        
        char cache = board[row][col];
        board[row][col] = '*';
        bool isExist = 
            DFS(board, word, row + 1, col, idx + 1) 
            || DFS(board, word, row - 1, col, idx + 1) 
            || DFS(board, word, row, col + 1, idx + 1) 
            || DFS(board, word, row, col - 1, idx + 1);
        
        board[row][col] = cache;
        return isExist;
    }
}
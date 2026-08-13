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
        var result = new List<string>();
        var root = BuildTrie(words);

        int rows = board.Length;
        int cols = board[0].Length;

        for (int r = 0; r < rows; r++) 
        {
            for (int c = 0; c < cols; c++)
                DFS(board, r, c, root, result);
        }

        return result;
    }

    private void DFS(char[][] board, int r, int c, TrieNode node, List<string> result) 
    {
        if (r < 0 
            || r >= board.Length 
            || c < 0 
            || c >= board[0].Length) 
            return;
        
        char ch = board[r][c];
        if (ch == '#' 
            || node.Children[ch - 'a'] == null) 
            return;

        node = node.Children[ch - 'a'];

        if (node.Word != null) 
        {
            result.Add(node.Word);
            node.Word = null;
        }

        board[r][c] = '#';

        DFS(board, r + 1, c, node, result);
        DFS(board, r - 1, c, node, result);
        DFS(board, r, c + 1, node, result);
        DFS(board, r, c - 1, node, result);

        board[r][c] = ch;
    }

    private TrieNode BuildTrie(IList<string> words) 
    {
        var root = new TrieNode();
        foreach (string word in words) 
        {
            TrieNode curr = root;
            foreach (char ch in word) 
            {
                int index = ch - 'a';
                if (curr.Children[index] == null)
                    curr.Children[index] = new TrieNode();
                curr = curr.Children[index];
            }
            curr.Word = word;
        }
        return root;
    }
}
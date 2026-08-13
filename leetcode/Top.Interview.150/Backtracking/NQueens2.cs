namespace Top.Interview._150.Backtracking;

public class NQueens2
{
    /// <summary>
    /// # 52
    /// https://leetcode.com/problems/n-queens-ii/description/
    /// The n-queens puzzle is the problem of placing n queens on an n x n 
    /// chessboard such that no two queens attack each other.
    /// Given an integer n, return the number of distinct solutions 
    /// to the n-queens puzzle.
    /// </summary>
    public int Execute(int n)
    {
        int result = 0;
        DFS(n, 0, new bool[n], new bool[2 * n - 1], new bool[2 * n - 1], ref result);
        return result;
    }

    private void DFS(int n, int i, bool[] cols, bool[] diag1, bool[] diag2, ref int ans)
    {
        if (i == n) 
        {
            ans++;
            return;
        }

         for (int j = 0; j < n; j++) 
         {
            if (cols[j] || diag1[i + j] 
                || diag2[j - i + n - 1])
                continue;
            
            cols[j] = diag1[i + j] = diag2[j - i + n - 1] = true;
            DFS(n, i + 1, cols, diag1, diag2, ref ans);
            cols[j] = diag1[i + j] = diag2[j - i + n - 1] = false;
        }
    }
}
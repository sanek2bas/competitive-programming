namespace Top.Interview._150.Multidimensional_DP;

public class EditDistance
{
    /// <summary>
    /// # 72
    /// https://leetcode.com/problems/edit-distance/description/
    /// Given two strings word1 and word2, return the minimum number 
    /// of operations required to convert word1 to word2.
    /// You have the following three operations permitted on a word:
    /// -insert a character
    /// -delete a character
    /// -replace a character
    /// </summary>
    public int Execute(string word1, string word2)
    {
        var rows = word1.Length;
        var cols = word2.Length;

        var dp = new int[rows + 1, cols + 1];
        for (int i = 0; i <= rows; i++)
            dp[i, 0] = i;
        for (int j = 0; j <= cols; j++)
            dp[0, j] = j;
        
        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= cols; col++)
            {
                int prevDiag = dp[row-1, col-1];
                if (word1[row-1] == word2[col-1])
                {
                    dp[row, col] = prevDiag;
                }
                else
                {
                    int prevLeft = dp[row-1, col];
                    int prevTop = dp[row, col-1];
                    dp[row, col] = 1 +
                        Math.Min(prevDiag, Math.Min(prevLeft, prevTop));
                }
            }
        }

        return dp[rows, cols];
    }
}
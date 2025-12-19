namespace Top.Interview._150.Multidimensional_DP;

public class MaximalSquare
{
    /// <summary>
    /// # 221
    /// https://leetcode.com/problems/maximal-square/description/
    /// Given an m x n binary matrix filled with 0's and 1's, 
    /// find the largest square containing only 1's and return its area.
    /// </summary>
    public int Execute(char[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        var dp = new int[rows][];
        for(int r = 0; r < rows; r++)
            dp[r] = new int[cols];
        var maxLength = 0;

        for(int row = 0; row < rows; row++)
        {
            for(int col = 0; col < cols; col++)
            {
                if (row == 0 
                    || col == 0 
                    || matrix[row][col] == '0')
                {
                    dp[row][col] = matrix[row][col] == '1' ? 1 : 0;
                }
                else
                {
                    dp[row][col] = Math.Min(
                        Math.Min(dp[row - 1][col], dp[row][col-1]), 
                        dp[row - 1][col - 1]) + 1;
                }
                maxLength = Math.Max(maxLength, dp[row][col]);
            }
        }
        return maxLength * maxLength;
    }
}
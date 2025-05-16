using System;

namespace TopInterview150.Multidimensional_DP;

public static class UniquePathsII
{
    /// <summary>
    /// You are given an m x n integer array grid. 
    /// There is a robot initially located at the top-left corner (i.e., grid[0][0]). 
    /// The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). 
    /// The robot can only move either down or right at any point in time.
    /// An obstacle and space are marked as 1 or 0 respectively in grid. 
    /// A path that the robot takes cannot include any square that is an obstacle.
    /// Return the number of possible unique paths that the robot can take to reach the bottom-right corner.
    /// The testcases are generated so that the answer will be less than or equal to 2 * 10^9.
    /// </summary>
    public static int Execute(int[][] grid)
    {
        int row = grid.Length;
        int col = grid[0].Length;
        int[] dp = new int[col];
        dp[0] = 1;

        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                if (grid[i][j] == 1)
                    dp[j] = 0;
                else if (j > 0)
                    dp[j] += dp[j-1];             
            }
        }
        return dp[col-1];
    }

    public static IEnumerable<(int[][] grid, int answer)> GetTests()
    {
        yield return (
            new int[][]
            {
                new int[] { 0, 0, 0 },
                new int[] { 0, 1, 0 },
                new int[] { 0, 0, 0 }
            },
            2);
        yield return (
            new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 0, 0 }
            },
            1);
        }

    public static bool CheckResult(int result, int answer)
    {
        return result == answer;
    }
}

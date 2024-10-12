using System;

namespace TopInterview150.Multidimensional_DP;

public class MinimumPathSum
{
    /// <summary>
    /// Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, 
    /// which minimizes the sum of all numbers along its path.
    /// Note: You can only move either down or right at any point in time.
    /// </summary>
    public static int Execute(int[][] grid)
    {
        if (grid.Length == 0)
            return 0;
        int row = grid.Length;
        int col = grid[0].Length;
        for(int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < col; j++)
            {
                if(i > 0 && j > 0)
                    grid[i][j] += Math.Min(grid[i-1][j], grid[i][j-1]);
                else if(i > 0)
                    grid[i][0] += grid[i-1][0];
                else if (j > 0)
                    grid[0][j] += grid[0][j-1]; 
            }
        }
        return grid[row-1][col-1];
    }

    public static IEnumerable<(int[][] grid, int answer)> GetTests()
    {
        yield return (
            new int[][]
            {
                new int[] { 1, 3, 1 },
                new int[] { 1, 5, 1 },
                new int[] { 4, 2, 1 }
            },
            7);
        yield return (
            new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 }
            },
            12);
        }

    public static bool CheckResult(int result, int answer)
    {
        return result == answer;
    }
}

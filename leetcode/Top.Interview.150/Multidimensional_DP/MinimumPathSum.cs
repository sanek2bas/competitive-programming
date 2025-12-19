namespace Top.Interview._150.Multidimensional_DP;

public class MinimumPathSum
{
    /// <summary>
    /// # 64
    /// https://leetcode.com/problems/minimum-path-sum/description/
    /// Given a m x n grid filled with non-negative numbers, 
    /// find a path from top left to bottom right, 
    /// which minimizes the sum of all numbers along its path.
    /// Note: You can only move either down or right at any point in time.
    /// </summary>
    public int Execute(int[][] grid)
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
}

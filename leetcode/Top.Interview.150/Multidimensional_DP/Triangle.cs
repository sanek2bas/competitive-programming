namespace Top.Interview._150.Multidimensional_DP;

public class Triangle
{
    /// <summary>
    /// # 120
    /// https://leetcode.com/problems/triangle/description/
    /// Given a triangle array, return the minimum path sum from top to bottom.
    /// For each step, you may move to an adjacent number of the row below. 
    /// More formally, if you are on index i on the current row, 
    /// you may move to either index i or index i + 1 on the next row.
    /// </summary>
    public int Execute(IList<IList<int>> triangle)
    {
        if (triangle.Count == 1)
            return triangle[0][0];

        int size = triangle.Count;
        int[] dp = new int[size+1];
        for (int i = size - 1; i >= 0; i--)
        {
            for(int j = 0; j <= i; j++)
            {
                int currentRowVal = triangle[i][j];
                dp[j] = Math.Min(dp[j], dp[j+1]) + currentRowVal;
            }
        }

        return dp[0];
    }
}

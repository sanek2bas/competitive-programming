using System;

namespace TopInterview150.Multidimensional_DP;

public static class Triangle
{
    /// <summary>
    /// Given a triangle array, return the minimum path sum from top to bottom.
    /// For each step, you may move to an adjacent number of the row below. 
    /// More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.
    /// </summary>
    public static int Execute(IList<IList<int>> triangle)
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

    public static IEnumerable<(IList<IList<int>> triangle, int answer)> GetTests()
    {
        yield return (
            new List<IList<int>> 
            { 
                new List<int> { 2 },
                new List<int> { 3, 4 },
                new List<int> { 6, 5, 7 },
                new List<int> { 4, 1, 8, 3 }
            }, 11);
        yield return (
            new List<IList<int>> 
            { 
                new List<int> { -10 }
            }, -10);
    }

    public static bool CheckResult(int result, int answer)
    {
        return result == answer;
    }
}

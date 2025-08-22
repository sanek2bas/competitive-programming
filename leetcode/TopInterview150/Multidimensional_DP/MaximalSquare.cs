namespace TopInterview150.MultidimensionalDP
{
    public static class MaximalSquare
    {
        /// <summary>
        /// Given an m x n binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.
        /// </summary>
        public static int Execute(char[][] matrix)
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
                    if (row == 0 || col == 0 || matrix[row][col] == '0')
                        dp[row][col] = matrix[row][col] == '1' ? 1 : 0;
                    else
                        dp[row][col] = Math.Min(Math.Min(dp[row - 1][col], dp[row][col-1]), dp[row - 1][col - 1]) + 1;
                    maxLength = Math.Max(maxLength, dp[row][col]);
                }
            }
            return maxLength * maxLength;
        }

        public static IEnumerable<(char[][] matrix, int answer)> GetTests()
        {
            yield return (
                new char[][] 
                {
                    new char[] { '1', '0', '1', '0', '0' },
                    new char[] { '1', '0', '1', '1', '1' },
                    new char[] { '1', '1', '1', '1', '1' },
                    new char[] { '1', '0', '0', '1', '0' }
                },
                4);
            yield return (
                new char[][]
                {
                    new char[] { '0', '1' },
                    new char[] { '1', '0' }
                },
                1);
            yield return (
                new char[][]
                {
                    new char[] { '0' }
                },
                0);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

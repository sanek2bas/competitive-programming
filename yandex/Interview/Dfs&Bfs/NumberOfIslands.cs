namespace Interview.Dfs_Bfs
{
    public static class NumberOfIslands
    {
        /// <summary>
        /// Given an m x n 2D binary grid, grid which represents a map of '1's (land) and '0's (water), return the number of islands.
        /// An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
        /// You may assume all four edges of the grid are all surrounded by water.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int Execute(char[][] grid)
        {
            var result = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            var visited = new bool[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == '0' ||
                        visited[r, c] == true)
                        continue;
                    result++;
                    dfs(grid, r, c, visited);
                }
            }

            return result;
        }

        private static void dfs(char[][] grid, int row, int col, bool[,] visited)
        {
            if (!isCheck(grid, row, col) ||
                grid[row][col] == '0' ||
                visited[row, col] == true)
                return;

            visited[row, col] = true;
            dfs(grid, row, col - 1, visited);
            dfs(grid, row - 1, col, visited);
            dfs(grid, row, col + 1, visited);
            dfs(grid, row + 1, col, visited);
        }

        private static bool isCheck(char[][] grid, int row, int col)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length;
        }

        public static IEnumerable<(char[][] grid, int answer)> GetTests()
        {
            yield return (
                new char[][]
                {
                    new char[] {'1', '1', '1', '1', '0'},
                    new char[] {'1', '1', '0', '1', '0'},
                    new char[] {'1', '1', '0', '0', '0'},
                    new char[] {'0', '0', '0', '0', '0'}
                }, 
                1);

            yield return (
                new char[][]
                {
                    new char[] {'1', '1', '0', '0', '0'},
                    new char[] {'1', '1', '0', '0', '0'},
                    new char[] {'0', '0', '1', '0', '0'},
                    new char[] {'0', '0', '0', '1', '1'}
                },
                3);
        }
    }
}

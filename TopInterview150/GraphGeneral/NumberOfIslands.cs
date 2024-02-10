﻿namespace TopInterview150.GraphGeneral
{
    public static class NumberOfIslands
    {
        /// <summary>
        /// Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
        /// An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
        /// You may assume all four edges of the grid are all surrounded by water.
        /// </summary>
        public static int Execute(char[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            var visited = new bool[rows, cols];
            var result = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == '1' &&
                        visited[r, c] == false)
                    {
                        result++;
                        DFS(grid, r, c, visited);
                    }
                }
            }
            return result;
        }

        private static void DFS(char[][] grid, int row, int col, bool[,] visited)
        {
            if (row < 0 ||
                col < 0 ||
                row >= grid.Length ||
                col >= grid[0].Length)
                return;
            if (grid[row][col] == '0')
                return;
            if (visited[row, col] == true)
                return;

            visited[row, col] = true;

            DFS(grid, row - 1, col, visited);
            DFS(grid, row + 1, col, visited);
            DFS(grid, row, col - 1, visited);
            DFS(grid, row, col + 1, visited);

        }

        public static IEnumerable<(char[][] grid, int answer)> GetTests()
        {
            yield return (
                new char[][]
                {
                    new char[] { '1', '1', '1', '1', '0' }, 
                    new char[] { '1', '1', '0', '1', '0' }, 
                    new char[] { '1', '1', '0', '0', '0' }, 
                    new char[] { '0', '0', '0', '0', '0' }, 
                }, 
                1);
            yield return (
                new char[][]
                {
                    new char[] { '1', '1', '0', '0', '0' },
                    new char[] { '1', '1', '0', '0', '0' },
                    new char[] { '0', '0', '1', '0', '0' },
                    new char[] { '0', '0', '0', '1', '1' },
                },
                3);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

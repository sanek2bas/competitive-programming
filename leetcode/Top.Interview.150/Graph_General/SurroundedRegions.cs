namespace Top.Interview._150.Graph_General;

public class SurroundedRegions
{
    /// <summary>
    /// # 130
    /// https://leetcode.com/problems/surrounded-regions/description/
    /// You are given an m x n matrix board containing letters 'X' and 'O',
    /// capture regions that are surrounded:
    /// Connect: A cell is connected to adjacent cells horizontally or vertically.
    /// Region: To form a region connect every 'O' cell.
    /// Surround: The region is surrounded with 'X' cells if you can connect
    /// the region with 'X' cells and none of the region cells are 
    /// on the edge of the board.
    /// A surrounded region is captured by replacing all 'O's with 'X's 
    /// in the input matrix board.
    /// </summary>
    public void Execute(char[][] board)
    {
        if (board.Length == 0)
            return;
        int row = board.Length;
        int col = board[0].Length;
        int[][] dirs = new int[][]
        {
            [0, 1], 
            [1, 0], 
            [0, -1], 
            [-1, 0]
        };
        Queue<(int, int)> queue = new Queue<(int, int)>();

        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                if(i * j == 0 || i == row - 1 || j == col - 1)
                {
                    if(board[i][j] == 'O')
                    {
                        queue.Enqueue((i, j));
                        board[i][j] = '*';
                    }
                }
            }
        }

        while(queue.Count > 0)
        {
            var val = queue.Dequeue();
            var i = val.Item1;
            var j = val.Item2;
            foreach(int[] dir in dirs) 
            {
                int x = i + dir[0];
                int y = j + dir[1];
                if (x < 0 || x == row || y < 0 || y == col)
                    continue;
                if (board[x][y] != 'O')
                    continue;
                queue.Enqueue((x, y));
                board[x][y] = '*';      
            }
        }

        foreach(char[] r in board)
        {
            for(int c = 0; c < r.Length; c++)
            {
                if (r[c] == '*')
                    r[c] = 'O';
                else if (r[c] == 'O')
                    r[c] = 'X';
            }
        }
    }
}
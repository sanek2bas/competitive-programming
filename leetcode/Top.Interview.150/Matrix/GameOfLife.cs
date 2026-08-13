namespace Top.Interview._150.Matrix;

public class GameOfLife
{
    /// <summary>
    /// # 289
    /// https://leetcode.com/problems/game-of-life/description/
    /// According to Wikipedia's article: "The Game of Life, also known simply as Life, 
    /// is a cellular automaton devised by the British mathematician John Horton Conway in 1970."
    /// The board is made up of an m x n grid of cells, where each cell has an initial state: 
    /// live (represented by a 1) or dead (represented by a 0). Each cell interacts with its
    /// eight neighbors (horizontal, vertical, diagonal) using the 
    /// following four rules (taken from the above Wikipedia article):
    /// 1. Any live cell with fewer than two live neighbors dies as if caused by under-population.
    /// 2. Any live cell with two or three live neighbors lives on to the next generation.
    /// 3. Any live cell with more than three live neighbors dies, as if by over-population.
    /// 4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
    /// The next state of the board is determined by applying the above rules simultaneously 
    /// to every cell in the current state of the m x n grid board.
    ///  In this process, births and deaths occur simultaneously.
    /// Given the current state of the board, update the board to reflect its next state.
    /// Note that you do not need to return anything.
    /// </summary>
    public void Execute(int[][] board)
    {
        if (board == null 
            || board.Length == 0 
            || board[0].Length == 0) 
            return;
        
        int rows = board.Length;
        int cols = board[0].Length;
        
        int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
        
        for (int row = 0; row < rows; row++) 
        {
            for (int col = 0; col < cols; col++) 
            {
                int liveNeighbors = 0;
                
                for (int i = 0; i < 8; i++) 
                {
                    int neighborRow = row + dx[i];
                    int neighborCol = col + dy[i];
                    
                    if (neighborRow >= 0 
                        && neighborRow < rows 
                        && neighborCol >= 0 
                        && neighborCol < cols) 
                    {
                        if (board[neighborRow][neighborCol] == 1 
                            || board[neighborRow][neighborCol] == 2) 
                            liveNeighbors++;
                    }
                }
                
                if (board[row][col] == 1) 
                {
                    if (liveNeighbors < 2 
                        || liveNeighbors > 3)
                        board[row][col] = 2;
                } 
                else if (board[row][col] == 0) 
                {
                    if (liveNeighbors == 3) 
                        board[row][col] = -1;
                }
            }
        }        

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++) 
            {
                if (board[row][col] == 2)
                    board[row][col] = 0;
                else if (board[row][col] == -1)
                    board[row][col] = 1;
            }
        }
    }
}
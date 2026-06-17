namespace Top.Interview._150.Matrix;

public class SetMatrixZeroes
{
    /// <summary>
    /// # 73
    /// https://leetcode.com/problems/set-matrix-zeroes/description/
    /// Given an m x n integer matrix matrix, if an element is 0, 
    /// set its entire row and column to 0's.
    /// You must do it in place.
    /// </summary>
    public void Execute(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        bool firstRowHasZero = false;

        for (int row = 0; row < rows; row++) 
        {
            for (int col = 0; col < cols; col++) 
            {
                if (matrix[row][col] == 0) 
                {
                    if (row == 0) 
                        firstRowHasZero = true;
                    else
                        matrix[row][0] = 0;
                    
                    matrix[0][col] = 0;
                }
            }
        }

        for (int r = 1; r < rows; r++) 
        {
            for (int c = 1; c < cols; c++) 
            {
                if (matrix[r][0] == 0 
                    || matrix[0][c] == 0)
                    matrix[r][c] = 0;
            }
        }

        if (matrix[0][0] == 0)
        {
            for (int r = 0; r < rows; r++)
                matrix[r][0] = 0;
        }

        if (firstRowHasZero) 
        {
            for (int c = 0; c < cols; c++) 
                matrix[0][c] = 0;
        }
    }
}
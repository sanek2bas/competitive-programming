namespace Top.Interview._150.Matrix;

public class SpiralMatrix
{
    /// <summary>
    /// # 54
    /// https://leetcode.com/problems/spiral-matrix/description/
    /// Given an m x n matrix, return all elements of the matrix in spiral order.
    /// </summary>
    public IList<int> Execute(int[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        var answers = new List<int>();
        int begRow = 0;
        int begCol = 0;
        int endRow = rows - 1;
        int endCol = cols - 1;
        while (answers.Count < cols * rows)
        {
            for (int c = begCol; 
                 c <= endCol && answers.Count < cols * rows; 
                 c++)
                answers.Add(matrix[begRow][c]);

            for (int r = begRow + 1; 
                 r <= endRow && answers.Count < cols * rows; 
                 r++)
                answers.Add(matrix[r][endCol]);

            for (int c = endCol - 1; 
                 c >= begCol && answers.Count < cols * rows; 
                 c--)
                answers.Add(matrix[endRow][c]);

            for (int r = endRow - 1; 
                 r > begRow && answers.Count < cols * rows; 
                 r--)
                answers.Add(matrix[r][begCol]);

            begRow++;
            begCol++;
            endRow--;
            endCol--;
        }
        return answers;
    }
}
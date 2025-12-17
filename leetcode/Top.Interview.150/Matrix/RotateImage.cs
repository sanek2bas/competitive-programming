namespace Top.Interview._150.Matrix;

public class RotateImage
{
    /// <summary>
    /// # 48
    /// https://leetcode.com/problems/rotate-image/description/
    /// You are given an n x n 2D matrix representing an image, 
    /// rotate the image by 90 degrees (clockwise).
    /// You have to rotate the image in-place, 
    /// which means you have to modify the input 2D matrix directly.
    /// DO NOT allocate another 2D matrix and do the rotation.
    /// </summary>
    public void Execute(int[][] matrix)
    {
        for (int i = 0, j = matrix.Length - 1; i < j; i++, j--)
        {
            int[] temp = matrix[i];
            matrix[i] = matrix[j];
            matrix[j] = temp;
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = i + 1; j < matrix.Length; j++)
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }
    }
}

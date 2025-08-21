namespace TopInterview150.SlidingWindow
{
    public static class RotateImage
    {
        /// <summary>
        /// You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
        /// You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.
        /// DO NOT allocate another 2D matrix and do the rotation.
        /// </summary>
        public static void Execute(int[][] matrix)
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

        public static IEnumerable<(int[][] matrix, int[][] answer)> GetTests()
        {
            yield return (
                new int[][] 
                {
                    new int[] { 1, 2, 3 },
                    new int[] { 4, 5, 6 },
                    new int[] { 7, 8, 9 }
                },
                new int[][]
                {
                    new int[] { 7, 4, 1 },
                    new int[] { 8, 5, 2 },
                    new int[] { 9, 6, 3 }
                });
            yield return (
                new int[][]
                {
                    new int[] { 5, 1, 9, 11 },
                    new int[] { 2, 4, 8, 10 },
                    new int[] { 13, 3, 6, 7 },
                    new int[] { 15, 14, 12, 16 }
                },
                new int[][]
                {
                    new int[] { 15, 13, 2, 5 },
                    new int[] { 14, 3, 4, 1 },
                    new int[] { 12, 6, 8, 9 },
                    new int[] { 16, 7, 10, 11 }
                });
        }

        public static bool CheckResult(int[][] result, int[][] answer)
        {
            if(result.Length != answer.Length)
                return false;
            for (int i = 0; i < result.Length; i++)
            {
                if (!result[i].SequenceEqual(answer[i]))
                    return false;
            }
            return true;
        }
    }
}

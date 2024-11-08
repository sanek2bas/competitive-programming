﻿namespace TopInterview150.Matrix
{
    public static class SpiralMatrix
    {
        /// <summary>
        /// Given an m x n matrix, return all elements of the matrix in spiral order.
        /// </summary>
        public static IList<int> Execute(int[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var answers = new List<int>();
            int begRow = 0;
            int begCol = 0;
            int endRow = rows - 1;
            int endCol = cols - 1;
            while(answers.Count < cols * rows)
            {
                for(int c = begCol; c <= endCol && answers.Count < cols * rows; c++)
                    answers.Add(matrix[begRow][c]);

                for(int r = begRow + 1; r <= endRow && answers.Count < cols * rows; r++)
                    answers.Add(matrix[r][endCol]);

                for(int c = endCol - 1; c >= begCol && answers.Count < cols * rows; c--)
                    answers.Add(matrix[endRow][c]);

                for (int r = endRow - 1; r > begRow && answers.Count < cols * rows; r--)
                    answers.Add(matrix[r][begCol]);

                begRow++;
                begCol++;
                endRow--;
                endCol--;
            }
            return answers;
        }

        public static IEnumerable<(int[][] matrix, IList<int> answer)> GetTests()
        {
            yield return (
                new int[][]
                {
                    new int[] { 1, 2, 3 },
                    new int[] { 4, 5, 6 },
                    new int[] { 7, 8, 9 }
                },
                new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 });
            yield return (
                new int[][]
                {
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 5, 6, 7, 8 },
                    new int[] { 9, 10, 11, 12 }
                },
                new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 });
        }

        public static bool CheckResult(IList<int> result, IList<int> answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}

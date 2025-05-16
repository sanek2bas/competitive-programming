namespace TopInterview150.BinarySearch
{
    public static class Search2DMatrix
    { 
        /// <summary>
        /// You are given an m x n integer matrix matrix with the following two properties:
        /// Each row is sorted in non-decreasing order.
        /// The first integer of each row is greater than the last integer of the previous row.
        /// Given an integer target, return true if target is in matrix or false otherwise.
        /// You must write a solution in O(log(m* n)) time complexity.
        /// </summary>
        public static bool Execute(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int left = 0;
            int right = rows * cols;

            while (left < right)
            {
                int mid = (left + right) / 2;
                int row = mid / cols;
                int col = mid % cols;
                if (matrix[row][col] == target)
                    return true;
                if (matrix[row][col] > target)
                    right = mid;
                else
                    left = mid + 1;
            }
            return false;
        }

        public static IEnumerable<(int[][] matrix, int target, bool answer)> GetTests()
        {
            yield return (
                new int[3][]
                {
                    new int[] { 1, 3, 5, 7 },
                    new int[] { 10, 11, 16, 20 },
                    new int[] { 23, 30, 34, 60 }
                },
                3, 
                true);
            yield return (
                new int[3][]
                {
                    new int[] { 1,3,5,7 },
                    new int[] { 10, 11, 16, 20 },
                    new int[] { 23, 30, 34, 60 }
                },
                13,
                false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}

namespace TopInterview150.Matrix
{
    public static class ValidSudoku
    {
        /// <summary>
        /// Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
        /// Each row must contain the digits 1-9 without repetition.
        /// Each column must contain the digits 1-9 without repetition.
        /// Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        /// Note:
        /// A Sudoku board (partially filled) could be valid but is not necessarily solvable.
        /// Only the filled cells need to be validated according to the mentioned rules.
        /// </summary>
        public static bool Execute(char[][] board)
        {
            var hashSet = new HashSet<string>();
            for(int row = 0; row < 9; row++)
            {
                for(int col = 0; col < 9; col++)
                {
                    var ch = board[row][col];
                    if (ch == '.')
                        continue;
                    
                    var strKey = $"{ch}row{row}";
                    if (hashSet.Contains(strKey))
                        return false;
                    hashSet.Add(strKey);

                    strKey = $"{ch}col{col}";
                    if (hashSet.Contains(strKey))
                        return false;
                    hashSet.Add(strKey);

                    strKey = $"{ch}box{row/3}{col/3}";
                    if (hashSet.Contains(strKey))
                        return false;
                    hashSet.Add(strKey);
                }
            }
            return true;
        }

        public static IEnumerable<(char[][] board, bool answer)> GetTests()
        {
            yield return (
                new char[][]
                {
                    new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                    new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                    new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                    new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                    new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                    new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                    new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                    new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
                },
                true);
            yield return (
               new char[][]
               {
                    new char[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                    new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                    new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                    new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                    new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                    new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                    new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                    new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
               },
               false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}

namespace Top.Interview._150.Matrix;

public class ValidSudoku
{
    public bool Execute(char[][] board)
    {
        var hashSet = new HashSet<string>();
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
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

                strKey = $"{ch}box{row / 3}{col / 3}";
                if (hashSet.Contains(strKey))
                    return false;
                hashSet.Add(strKey);
            }
        }
        return true;
    }
}

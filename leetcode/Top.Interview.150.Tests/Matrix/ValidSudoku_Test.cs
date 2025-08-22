using Top.Interview._150.Matrix;

namespace Matrix;

public class ValidSudoku_Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public void ValidSudoku(char[][] board, bool answer)
    {
        var solution = new ValidSudoku();
        var result = solution.Execute(board);
        Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(char[][] board, bool answer)> DataSource()
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
           true);
    }
}

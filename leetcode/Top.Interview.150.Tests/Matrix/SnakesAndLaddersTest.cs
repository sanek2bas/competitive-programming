using Top.Interview._150.Matrix_Traversal;

namespace Matrix;

public class SnakesAndLaddersTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[][] board, int answer)
    {
        var solution = new SnakesAndLadders();
        var result = solution.Execute(board);
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[][] board, int answer)> DataSource()
    {
        yield return (
            new int[][]
            {
                new int[] { -1, -1, -1, -1, -1, -1 },
                new int[] { -1, -1, -1, -1, -1, -1 },
                new int[] { -1, -1, -1, -1, -1, -1 },
                new int[] { -1, 35, -1, -1, 13, -1 },
                new int[] { -1, -1, -1, -1, -1, -1 },
                new int[] { -1, 15, -1, -1, -1, -1 }
            },
            4);
        yield return (
            new int[][]
            {
                new int[] { -1, -1},
                new int[] { -1, 3}
            },
            1);
    }
}
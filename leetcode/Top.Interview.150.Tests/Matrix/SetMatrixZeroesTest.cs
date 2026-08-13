using Top.Interview._150.Matrix;

namespace Matrix;

public class SetMatrixZeroesTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[][] matrix, int[][] answer)
    {
        var solution = new SetMatrixZeroes();

        solution.Execute(matrix);
        
        await Assert.That(matrix).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[][] matrix, int[][] answer)> DataSource()
    {
        yield return (
            new int[][]
            {
                [0, 1, 2, 0],
                [3, 4, 5, 2],
                [1, 3, 1, 5]
            },
            new int[][] { 
                [0, 0, 0, 0],
                [0, 4, 5, 0],
                [0, 3, 1, 0]
            });
    }
}
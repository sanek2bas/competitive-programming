using Top.Interview._150.Matrix;

namespace Matrix;

public class GameOfLifeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[][] matrix, int[][] answer)
    {
        var solution = new GameOfLife();

        solution.Execute(matrix);
        
        await Assert.That(matrix).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[][] matrix, int[][] answer)> DataSource()
    {
        yield return (
            new int[][]
            {
                [0, 1, 0],
                [0, 0, 1],
                [1, 1, 1],
                [0, 0, 0]
            },
            new int[][] { 
                [0, 0, 0],
                [1, 0, 1],
                [0, 1, 1],
                [0, 1, 0]
            });
        
        yield return (
            new int[][]
            {
                [1, 1],
                [1, 0]
            },
            new int[][] { 
                [1, 1],
                [1, 1]
            });
    }
}
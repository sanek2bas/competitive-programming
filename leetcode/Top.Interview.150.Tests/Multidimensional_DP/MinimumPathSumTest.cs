using Top.Interview._150.Multidimensional_DP;

namespace Multidimensional_DP;

public class MinimumPathSumTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[][] grid, int answer)
    {
        var solution = new MinimumPathSum();

        var result = solution.Execute(grid);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[][] grid, int answer)> DataSource()
    {
        yield return (
            new int[][]
            {
                [1, 3, 1],
                [1, 5, 1],
                [4, 2, 1]
            },
            7);
        yield return (
            new int[][]
            {
                [1, 2, 3],
                [4, 5, 6]
            },
            12);
    }
}
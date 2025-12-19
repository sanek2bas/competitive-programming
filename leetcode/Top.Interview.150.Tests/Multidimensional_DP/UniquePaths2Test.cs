using Top.Interview._150.Multidimensional_DP;

namespace Multidimensional_DP;

public class UniquePaths2Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[][] grid, int answer)
    {
        var solution = new UniquePaths2();

        var result = solution.Execute(grid);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[][] grid, int answer)> DataSource()
    {
        yield return (
            new int[][]
            {
                [0, 0, 0],
                [0, 1, 0],
                [0, 0, 0]
            },
            2);
        yield return (
            new int[][]
            {
                [0, 1],
                [0, 0]
            },
            1);
    }
}
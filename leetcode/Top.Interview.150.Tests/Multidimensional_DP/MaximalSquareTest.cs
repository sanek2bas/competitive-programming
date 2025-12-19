using Top.Interview._150.Multidimensional_DP;

namespace Multidimensional_DP;

public class MaximalSquareTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(char[][] matrix, int answer)
    {
        var solution = new MaximalSquare();

        var result = solution.Execute(matrix);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(char[][] matrix, int answer)> DataSource()
    {
         yield return (
            new char[][] 
            {
                ['1', '0', '1', '0', '0'],
                ['1', '0', '1', '1', '1'],
                ['1', '1', '1', '1', '1'],
                ['1', '0', '0', '1', '0']
            },
            4);
        yield return (
            new char[][]
            {
                ['0', '1'],
                ['1', '0']
            },
            1);
        yield return (
            new char[][]
            {
                ['0']
            },
            0);
    }
}
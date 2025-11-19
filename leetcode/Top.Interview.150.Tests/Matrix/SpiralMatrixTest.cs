using Top.Interview._150.Matrix;

namespace Matrix;

public class SpiralMatrix_Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task SpiralMatrix(int[][] matrix, IList<int> answer)
    {
        var solution = new SpiralMatrix();
        var result = solution.Execute(matrix);
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[][] matrix, IList<int> answer)> DataSource()
    {
        yield return (
            new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            },
            new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 });
        yield return (
            new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 }
            },
            new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 });
    }
}
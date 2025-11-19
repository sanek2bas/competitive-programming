using Top.Interview._150.Binary_Search;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace Binary_Search;

public class Search2DMatrixTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Search2DMatrix(int[][] matrix, int target, bool answer)
    {
        var solution = new Search2DMatrix();
        var result = solution.Execute(matrix, target);
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[][] matrix, int traget, bool answer)> DataSource()
    {
        yield return (
           new int[3][]
           {
               new int[] { 1, 3, 5, 7 },
               new int[] { 10, 11, 16, 20 },
               new int[] { 23, 30, 34, 60 }
           },
           3,
           true);
        yield return (
            new int[3][]
            {
                new int[] { 1, 3, 5, 7 },
                new int[] { 10, 11, 16, 20 },
                new int[] { 23, 30, 34, 60 }
            },
            13,
            false);
    }
}

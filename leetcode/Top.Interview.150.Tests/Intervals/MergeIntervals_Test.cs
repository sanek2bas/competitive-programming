using Top.Interview._150.Intervals;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace Intervals;

public class MergeIntervals_Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task MergeIntervals(int[][] intervals, int[][] answer)
    {
        var solution = new MergeIntervals();
        var result = solution.Execute(intervals);
        await Assert.That(result).IsEquivalentTo(answer);
    }
    public IEnumerable<(int[][] intervals, int[][] answer)> DataSource()
    {
        yield return (
            new int[][]
            {
                new int[] { 1, 3 },
                new int[] { 2, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            },
            new int[][]
            {
                new int[] { 1, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            });
        yield return (
            new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 4, 5 }
            },
            new int[][]
            {
                new int[] { 1, 5 }
            });
    }
}

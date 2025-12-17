using Top.Interview._150.Intervals;

namespace Intervals;

public class MergeIntervalsTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[][] intervals, int[][] answer)
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
                [1, 3],
                [2, 6],
                [8, 10],
                [15, 18]
            },
            new int[][]
            {
                [1, 6],
                [8, 10],
                [15, 18]
            });
        yield return (
            new int[][]
            {
                [1, 4],
                [4, 5]
            },
            new int[][]
            {
                [1, 5]
            });
    }
}

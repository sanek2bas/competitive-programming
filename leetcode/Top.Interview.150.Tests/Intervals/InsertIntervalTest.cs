using Top.Interview._150.Intervals;

namespace Intervals;

public class InsertIntervalTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(
        int[][] intervals, int[] newInterval,  int[][] answer)
    {
        var solution = new InsertInterval();

        var result = solution.Execute(intervals, newInterval);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }
    
    public IEnumerable<(int[][], int[], int[][])> DataSource()
    {
        yield return (
            new int[][] { [1, 3], [6, 9] },
            new int[] {2, 5},
            new int[][] { [1, 5], [6, 9] });

        yield return (
            new int[][] { [1, 2], [3, 5], [6, 7], [8, 10], [12, 16] },
            new int[] {4, 8},
            new int[][] { [1, 2], [3, 10], [12, 16] });
    }
}
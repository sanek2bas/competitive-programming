using Top.Interview._150.Intervals;

namespace Intervals;

public class SummaryRanges_Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task SummaryRanges(int[] nums, IList<string> answer)
    {
        var solution = new SummaryRanges();
        var result = solution.Execute(nums);
        await Assert.That(result).IsEquivalentTo(answer);
    }
    public IEnumerable<(int[] nums, IList<string> answer)> DataSource()
    {
        yield return (
            new int[] { 0, 1, 2, 4, 5, 7 },
            new List<string> { "0->2", "4->5", "7" });
        yield return (
            new int[] { 0, 2, 3, 4, 6, 8, 9 },
            new List<string> { "0", "2->4", "6", "8->9" });
    }
}

using Top.Interview._150.Tests.Array___String;

namespace Array___String;

internal class RotateArrayTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task RotateArray(int[] nums, int k, int[] answer)
    {
        var solution = new RotateArray();
        solution.Execute(nums, k);
        await Assert.That(nums).IsEquivalentTo(answer);
    }

    public static IEnumerable<(int[] nums, int k, int[] answer)> DataSource()
    {
        yield return (new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3,
                      new int[] { 5, 6, 7, 1, 2, 3, 4 });
        yield return (new int[] { -1, -100, 3, 99 }, 2,
                      new int[] { 3, 99, -1, -100 });
    }
}
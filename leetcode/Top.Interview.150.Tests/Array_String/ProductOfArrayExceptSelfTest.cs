using Top.Interview._150.Array_String;

namespace  Array_String;

public class ProductOfArrayExceptSelfTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, int[] answer)
    {
        var solution = new ProductOfArrayExceptSelf();

        var result = solution.Execute(nums);

        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[] nums, int[] answer)> DataSource()
    {
        yield return (
            new int[] { 1, 2, 3, 4 },
            new int[] { 24, 12, 8, 6 });
        yield return (
            new int[] { -1, 1, 0, -3, 3 },
            new int[] { 0, 0, 9, 0, 0 });
    }
}
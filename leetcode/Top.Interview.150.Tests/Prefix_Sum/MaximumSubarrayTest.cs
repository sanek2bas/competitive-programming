using Top.Interview._150.Prefix_Sum;

namespace Prefix_Sum;

public class MaximumSubarrayTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, int answer)
    {
        var solution = new MaximumSubarray();
        var result = solution.Execute(nums);        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] nums, int answer)> DataSource()
    {
        yield return (
            new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6);
        yield return (
            new int[] { 1 }, 1);
        yield return (
            new int[] { 5, 4, -1, 7, 8 }, 23);
    }
}
using Top.Interview._150.Kadane_Algorithm;

namespace Kadane_Algorithm;

public class MaximumSumCircularSubarrayTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, int answer)
    {
        var solution = new MaximumSumCircularSubarray();

        var result = solution.Execute(nums);    
            
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] nums, int answer)> DataSource()
    {
        yield return (new int[] { 1, -2, 3, -2 }, 3);
        yield return (new int[] { 5, -3, 5 }, 10);
        yield return (new int[] { -3, -2, -3 }, -2);
    }
}
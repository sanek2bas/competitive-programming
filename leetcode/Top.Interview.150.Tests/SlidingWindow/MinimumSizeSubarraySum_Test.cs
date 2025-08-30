using Top.Interview._150.SlidingWindow;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace SlidingWindow;

public class MinimumSizeSubarraySum_Test
{
    [Test]
    [Arguments(7, new int[] { 2, 3, 1, 2, 4, 3 }, 2)]
    [Arguments(4, new int[] { 1, 4, 4 }, 1)]
    [Arguments(11, new int[] { 1, 4, 4 }, 0)]
    public async Task MinimumSizeSubarraySum(int target, int[] nums, int answer)
    {
        var solution = new MinimumSizeSubarraySum();
        var result = solution.Execute(target, nums);
        await Assert.That(result).IsEqualTo(answer);
    }
}

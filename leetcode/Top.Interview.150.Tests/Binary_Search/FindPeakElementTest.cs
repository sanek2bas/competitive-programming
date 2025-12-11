using Top.Interview._150.Binary_Search;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace Binary_Search;

public class FindPeakElementTest
{
    [Test]
    [Arguments(new int[] { 1, 2, 3, 1 }, 2)]
    [Arguments(new int[] { 1, 2, 1, 3, 5, 6, 4 }, 5)]
    public async Task Solution(int[] nums, int answer)
    {
        var solution = new FindPeakElement();
        var result = solution.Execute(nums);
        await Assert.That(result).IsEqualTo(answer);
    }
}
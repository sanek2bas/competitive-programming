using Top.Interview._150.Binary_Search;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace Binary_Search;

public class SearchInRotatedSortedArrayTest
{
    [Test]
    [Arguments(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    [Arguments(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
    [Arguments(new int[] { 1 }, 0, -1)]
    public async Task Solution(int[] nums, int target, int answer)
    {
        var solution = new SearchInRotatedSortedArray();
        var result = solution.Execute(nums, target);
        await Assert.That(result).IsEqualTo(answer);
    }
}

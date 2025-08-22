using Top.Interview._150.Binary_Search;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace Binary_Search;

public class SearchInsertPosition_Test
{
    [Test]
    [Arguments(new int[] { 1, 3, 5, 6 }, 5, 2)]
    [Arguments(new int[] { 1, 3, 5, 6 }, 2, 1)]
    [Arguments(new int[] { 1, 3, 5, 6 }, 7, 4)]
    public async Task SearchInsertPosition(int[] nums, int target, int answer)
    {
        var solution = new SearchInsertPosition();
        var result = solution.Execute(nums, target);
        await Assert.That(result).IsEqualTo(answer);
    }
}
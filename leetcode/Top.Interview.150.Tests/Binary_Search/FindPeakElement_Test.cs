using Top.Interview._150.Binary_Search;

namespace Binary_Search;

public class FindPeakElement_Test
{
    [Test]
    [Arguments(new int[] { 1, 2, 3, 1 }, 2)]
    [Arguments(new int[] { 1, 2, 1, 3, 5, 6, 4 }, 5)]
    public async Task FindPeakElement(int[] nums, int answer)
    {
        var solution = new FindPeakElement();
        var result = solution.Execute(nums);
        await Assert.That(result).IsEqualTo(answer);
    }
}
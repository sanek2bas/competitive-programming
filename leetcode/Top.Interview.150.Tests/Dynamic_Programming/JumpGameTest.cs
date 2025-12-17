using Top.Interview._150.Dynamic_Programming;
using TopInterview150.Array_String;

namespace Dynamic_Programming;

public class JumpGameTest
{
    [Test]
    [Arguments(new int[] { 2, 3, 1, 1, 4 }, true)]
    [Arguments(new int[] { 3, 2, 1, 0, 4 }, false)]
    public async Task Solution(int[] nums, bool answer)
    {
        var solution = new JumpGame();

        var result = solution.Execute(nums);

        await Assert.That(result).IsEqualTo(answer);
    }
}
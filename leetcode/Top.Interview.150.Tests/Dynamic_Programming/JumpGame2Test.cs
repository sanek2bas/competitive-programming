using Top.Interview._150.Dynamic_Programming;

namespace Dynamic_Programming;

public class JumpGame2Test
{
    [Test]
    [Arguments(new int[] { 2, 3, 1, 1, 4 }, 2)]
    [Arguments(new int[] { 2, 3, 0, 1, 4 }, 2)]
    public async Task Solution(int[] nums, int answer)
    {
        var solution = new JumpGame2();

        var result = solution.Execute(nums);

        await Assert.That(result).IsEqualTo(answer);
    }
}
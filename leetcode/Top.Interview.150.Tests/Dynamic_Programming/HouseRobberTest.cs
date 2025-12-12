using Top.Interview._150.Dynamic_Programming;

namespace Dynamic_Programming;

public class HouseRobberTest
{
    [Test]
    [Arguments(new int[] { 1, 2, 3, 1}, 4)]
    [Arguments(new int[] { 2, 7, 9, 3, 1}, 12)]
    public async Task Solution(int[] nums, int answer)
    {
        var solution = new HouseRobber();
        
        var result = solution.Execute(nums);

        await Assert.That(result).IsEqualTo(answer);
    }
}
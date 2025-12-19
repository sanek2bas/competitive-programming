using Top.Interview._150._1D_DP;

namespace _1D_DP;

public class ClimbingStairsTest
{
    [Test]
    [Arguments(2, 2)]
    [Arguments(3, 3)]
    public async Task Solution(int n, int answer)
    {
        var solution = new ClimbingStairs();

        var result = solution.Execute(n);
        
        await Assert.That(result).IsEqualTo(answer);
    }
}
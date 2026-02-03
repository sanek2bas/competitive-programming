using Top.Interview._150.Mathematics;

namespace Mathematics;

public class FactorialTrailingZeroesTest
{
    [Test]
    [Arguments(3, 0)]
    [Arguments(5, 1)]
    [Arguments(0, 0)]
    [Arguments(100, 24)]
    public async Task Solution(int x, int answer)
    {
        var solution = new FactorialTrailingZeroes();

        var result = solution.Execute(x);
        
        await Assert.That(result).IsEqualTo(answer);
    }
}
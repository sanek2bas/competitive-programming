using Top.Interview._150.Mathematics;

namespace Mathematics;

public class IntegerToRomanTest
{
    [Test]
    [Arguments(3, "III")]
    [Arguments(58, "LVIII")]
    [Arguments(1994, "MCMXCIV")]
    public async Task Solution(int num, string answer)
    {
        var solution = new IntegerToRoman();

        var result = solution.Execute(num);
        
        await Assert.That(result).IsEqualTo(answer);
    }
}

using Top.Interview._150.Array_String;

namespace Array_String;

public class RomanToIntegerTest
{
    [Test]
    [Arguments("III", 3)]
    [Arguments("LVIII", 58)]
    [Arguments("MCMXCIV", 1994)]
    public async Task Solution(string romanNum, int answer)
    {
        var solution = new RomanToInteger();

        var result = solution.Execute(romanNum);

        await Assert.That(result).IsEqualTo(answer);
    }
}
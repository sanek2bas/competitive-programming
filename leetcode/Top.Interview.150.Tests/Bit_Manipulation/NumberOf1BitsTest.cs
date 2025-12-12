using Top.Interview._150.Bit_Manipulation;

namespace Bit_Manipulation;

public class NumberOf1BitsTest
{
    [Test]
    [Arguments(11, 3)]
    [Arguments(128, 1)]
    [Arguments(4_294_967_293, 31)]
    public async Task Solution(uint n, int answer)
    {
        var solution = new NumberOf1Bits();

        var result = solution.Execute(n);
        
        await Assert.That(result).IsEqualTo(answer);
    }
}
using Top.Interview._150.Bit_Manipulation;

namespace Bit_Manipulation;

public class BitwiseANDofNumbersRangeTest
{
    [Test]
    [Arguments(5, 7, 4)]
    [Arguments(0, 0, 0)]
    [Arguments(1, 2147483647, 0)]
    public async Task Solution(int left, int right, int answer)
    {
        var solution = new BitwiseANDofNumbersRange();

        var result = solution.Execute(left, right);
        
        await Assert.That(result).IsEqualTo(answer);
    }
}
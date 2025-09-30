using Top.Interview._150.Bit_Manipulation;

namespace Bit_Manipulation;

public class ReverseBits_Test
{
    [Test]
    [Arguments(43261596, 964176192)]
    [Arguments(4294967293, 3221225471)]
    public async Task ReverseBits(uint n, uint answer)
    {
        var solution = new ReverseBits();
        var result = solution.Execute(n);
        await Assert.That(result).IsEqualTo(answer);
    }
}
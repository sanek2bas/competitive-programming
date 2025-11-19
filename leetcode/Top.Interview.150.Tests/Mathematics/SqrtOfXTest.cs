using Top.Interview._150.Mathematics;

namespace Mathematics;

public class SqrtOfX_Test
{
    [Test]
    [Arguments(4, 2)]
    [Arguments(8, 2)]
    [Arguments(2147483647, 46340)]
    public async Task SqrtOfX(int x, int answer)
    {
        var solution = new SqrtOfX();
        var result = solution.Execute(x);
        await Assert.That(result).IsEqualTo(answer);
    }
}

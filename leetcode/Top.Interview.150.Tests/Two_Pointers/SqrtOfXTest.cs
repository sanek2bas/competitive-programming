using Top.Interview._150.Two_Pointers;

namespace Two_Pointers;

public class SqrtOfXTest
{
    [Test]
    [Arguments(4, 2)]
    [Arguments(8, 2)]
    [Arguments(2147483647, 46340)]
    public async Task Solution(int x, int answer)
    {
        var solution = new SqrtOfX();

        var result = solution.Execute(x);
        
        await Assert.That(result).IsEqualTo(answer);
    }
}

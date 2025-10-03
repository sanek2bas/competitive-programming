using Top.Interview._150.Mathematics;

namespace Mathematics;

public class PalindromeNumber_Test
{
    [Test]
    [Arguments(121, true)]
    [Arguments(-121, false)]
    [Arguments(10, false)]
    public async Task PalindromeNumber(int x, bool answer)
    {
        var solution = new PalindromeNumber();
        var result = solution.Execute(x);
        await Assert.That(result).IsEqualTo(answer);
    }
}
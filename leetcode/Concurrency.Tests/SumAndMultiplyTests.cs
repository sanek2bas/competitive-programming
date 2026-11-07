using System.Text;

namespace Concurrency.Tests;

public class SumAndMultiplyTests
{
    [Test]
    [Arguments(10203004, 12340)]
    [Arguments(1000, 1)]
    public async Task Solution(int n, long expected)
    {
        var solution = new SumAndMultiply();
        var result = solution.Execute(n);
        await Assert.That(result).IsEqualTo(expected);
    }
}

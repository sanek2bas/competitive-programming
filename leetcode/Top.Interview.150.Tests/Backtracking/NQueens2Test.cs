using Top.Interview._150.Backtracking;

namespace Backtracking;

public class NQueens2Test
{
    [Test]
    [Arguments(4, 2)]
    [Arguments(1, 1)]
    public async Task Solution(int n, int answer)
    {
        var solution = new NQueens2();

        var result = solution.Execute(n);
        
        await Assert.That(result).IsEqualTo(answer);
    }
}
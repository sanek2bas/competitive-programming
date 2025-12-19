using Top.Interview._150.Backtracking;

namespace Backtracking;

public class GenerateParenthesesTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int n, IList<string> answer)
    {
        var solution = new GenerateParentheses();

        var result = solution.Execute(n);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int n, IList<string> answer)> DataSource()
    {
        yield return (3,
            new List<string> { "((()))", "(()())", "(())()", "()(())", "()()()" });
        yield return (1,
            new List<string> { "()" });
    }
}
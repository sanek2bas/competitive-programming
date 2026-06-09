using Top.Interview._150.Stack;

namespace Stack;

public class EvaluateReversePolishNotationTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string[] tokens, int answer)
    {
        var solution = new EvaluateReversePolishNotation();

        var result = solution.Execute(tokens);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(string[] tokens, int answer)> DataSource()
    {
        yield return (
            new string[] { "2", "1", "+", "3", "*" },
            9
        );

        yield return (
            new string[] { "4", "13", "5", "/", "+" },
            6
        );

        yield return (
            new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"},
            22
        );
    }
}
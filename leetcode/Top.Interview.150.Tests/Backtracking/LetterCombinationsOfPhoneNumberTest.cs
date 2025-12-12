using Top.Interview._150.Backtracking;

namespace Backtracking;

public class LetterCombinationsOfPhoneNumberTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string digits, IList<string> answer)
    {
        var solution = new LetterCombinationsOfPhoneNumber();

        var result = solution.Execute(digits);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(string digits, IList<string> answer)> DataSource()
    {
        yield return (
            "23",
            new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" });
        yield return (
            "",
            new string[] { });
        yield return (
            "2",
            new string[] { "a", "b", "c" });
    }
}
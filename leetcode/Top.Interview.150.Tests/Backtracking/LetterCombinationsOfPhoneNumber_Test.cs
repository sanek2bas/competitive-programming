using Top.Interview._150.Backtacking;

using Backtracking;

public class LetterCombinationsOfPhoneNumber_Test
{
    [Test]
    [Arguments(
        "23",
        new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
    [Arguments(
        "",
        new string[] { })]
    [Arguments(
        "2",
        new string[] { "a", "b", "c"})]
    public async Task LetterCombinationsOfPhoneNumber(string digits, IList<string> answer)
    {
        var solution = new LetterCombinationsOfPhoneNumber();
        var result = solution.Execute(digits);
        await Assert.That(result).IsEquivalentTo(answer);
    }
}
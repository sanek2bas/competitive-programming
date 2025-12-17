using Top.Interview._150.Array_String;

namespace Array_String;

public class ReverseWordsInStringTest
{
    [Test]
    [Arguments("the sky is blue", "blue is sky the")]
    [Arguments("  hello world  ", "world hello")]
    [Arguments("a good   example", "example good a")]
    public async Task Solution(string s, string answer)
    {
        var solution = new ReverseWordsInString();

        var result = solution.Execute(s);

        await Assert.That(result).IsEqualTo(answer);
    }
}
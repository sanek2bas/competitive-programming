using Top.Interview._150.Sliding_Window;

namespace Sliding_Window;

public class MinimumWindowSubstringTest
{
    [Test]
    [Arguments("ADOBECODEBANC", "ABC", "BANC")]
    [Arguments("a", "a", "a")]
    [Arguments("a", "aa", "")]
    public async Task Solution(string s, string t, string answer)
    {
        var solution = new MinimumWindowSubstring();

        var result = solution.Execute(s, t);
        
        await Assert.That(result).IsEqualTo(answer);
    }
}
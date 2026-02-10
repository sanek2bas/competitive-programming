using Top.Interview._150.Multidimensional_DP;

namespace Multidimensional_DP;

public class LongestPalindromicSubstringTest
{
    [Test]
    [Arguments("babad", "bab")]
    [Arguments("cbbd", "bb")]
    public async Task Solution(string path, string answer)
    {
        var solution = new LongestPalindromicSubstring();        
        var result = solution.Execute(path);
        await Assert.That(result).IsEqualTo(answer);
    }
}
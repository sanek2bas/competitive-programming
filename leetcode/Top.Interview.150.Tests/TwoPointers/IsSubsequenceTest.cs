using Top.Interview._150.TwoPointers;

namespace TwoPointers;

public class IsSubsequenceTest
{
    [Test]
    [Arguments("abc", "ahbgdc", true)]
    [Arguments("axc", "ahbgdc", false)]
    public async Task Solution(string s, string t, bool answer)
    {
        var solution = new IsSubsequence();
        var result = solution.Execute(s, t);
        await Assert.That(result).IsEqualTo(answer);
    }
}
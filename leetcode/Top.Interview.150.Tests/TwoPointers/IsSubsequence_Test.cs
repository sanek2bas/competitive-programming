using Top.Interview._150.TwoPointers;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace TwoPointers;

public class IsSubsequence_Test
{
    [Test]
    [Arguments("abc", "ahbgdc", true)]
    [Arguments("axc", "ahbgdc", false)]
    public async Task IsSubsequence(string s, string t, bool answer)
    {
        var solution = new IsSubsequence();
        var result = solution.Execute(s, t);
        await Assert.That(result).IsEqualTo(answer);
    }
}
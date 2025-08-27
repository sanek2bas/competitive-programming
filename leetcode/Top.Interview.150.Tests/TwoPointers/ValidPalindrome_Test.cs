using Top.Interview._150.TwoPointers;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace TwoPointers;

public class ValidPalindrome_Test
{
    [Test]
    [Arguments("A man, a plan, a canal: Panama", true)]
    [Arguments("race a car", false)]
    [Arguments(" ", true)]
    public async Task ValidPalindrome(string s, bool answer)
    {
        var solution = new ValidPalindrome();
        var result = solution.Execute(s);
        await Assert.That(result).IsEqualTo(answer);
    }
}
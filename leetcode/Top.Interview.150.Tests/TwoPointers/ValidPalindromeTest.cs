using Top.Interview._150.TwoPointers;

namespace TwoPointers;

public class ValidPalindromeTest
{
    [Test]
    [Arguments("A man, a plan, a canal: Panama", true)]
    [Arguments("race a car", false)]
    [Arguments(" ", true)]
    public async Task Solution(string s, bool answer)
    {
        var solution = new ValidPalindrome();
        var result = solution.Execute(s);
        await Assert.That(result).IsEqualTo(answer);
    }
}
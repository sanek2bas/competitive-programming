using Top.Interview._150.Sliding_Window;

namespace Sliding_Window;

public class WithoutRepeatingCharactersTest
{
    [Test]
    [Arguments("abcabcbb", 3)]
    [Arguments("bbbbb", 1)]
    [Arguments("pwwkew", 3)]
    public async Task Solution(string s, int answer)
    {
        var solution = new WithoutRepeatingCharacters();
        
        var result = solution.Execute(s);

        await Assert.That(result).IsEqualTo(answer);
    }
}
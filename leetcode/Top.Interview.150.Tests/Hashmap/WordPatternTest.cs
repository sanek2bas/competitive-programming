using Top.Interview._150.Hashmap;

namespace Hashmap;

public class WordPatternTest
{
    [Test]
    [Arguments("abba", "dog cat cat dog", true)]
    [Arguments("abba", "dog cat cat fish", false)]
    [Arguments("aaaa", "dog cat cat dog", false)]
    public async Task Solution(string pattern, string str, bool answer)
    {
        var solution = new WordPattern();
        var result = solution.Execute(pattern, str);
        await Assert.That(result).IsEqualTo(answer);
    }
}
using Top.Interview._150.Hashmap;

namespace Hashmap;

public class IsomorphicStringsTest
{
    [Test]
    [Arguments("egg", "add", true)]
    [Arguments("foo", "bar", false)]
    [Arguments("paper", "title", true)]
    public async Task Solution(string ransomNote, string magazine, bool answer)
    {
        var solution = new IsomorphicStrings();

        var result = solution.Execute(ransomNote, magazine);

        await Assert.That(result).IsEqualTo(answer);
    }
}
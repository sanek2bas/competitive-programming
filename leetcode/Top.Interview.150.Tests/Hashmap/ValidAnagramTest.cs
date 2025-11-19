using Top.Interview._150.Hashmap;

namespace Hashmap;

public class ValidAnagramTest
{
    [Test]
    [Arguments("anagram", "nagaram", true)]
    [Arguments("rat", "car", false)]
    public async Task ValidAnagram(string s, string t, bool answer)
    {
        var solution = new ValidAnagram();
        var result = solution.Execute(s, t);
        await Assert.That(result).IsEqualTo(answer);
    }
}

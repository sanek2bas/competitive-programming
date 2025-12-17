using Top.Interview._150.Hashmap;

namespace Hashmap;

public class RansomNoteTest
{
    [Test]
    [Arguments("a", "b", false)]
    [Arguments("aa", "ab", false)]
    [Arguments("aa", "aab", true)]
    public async Task Solution(string ransomNote, string magazine, bool answer)
    {
        var solution = new RansomNote();

        var result = solution.Execute(ransomNote, magazine);

        await Assert.That(result).IsEqualTo(answer);
    }
}
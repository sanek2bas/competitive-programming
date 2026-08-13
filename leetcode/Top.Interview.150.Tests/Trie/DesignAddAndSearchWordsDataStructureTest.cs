using Top.Interview._150.Trie;

namespace Trie;

public class DesignAddAndSearchWordsDataStructureTest
{
    [Test]
    public async Task Solution()
    {
        var solution = new DesignAddAndSearchWordsDataStructure();

        solution.AddWord("bad");
        solution.AddWord("dad");
        solution.AddWord("mad");
        
        await Assert.That(solution.Search("pad")).IsFalse();
        await Assert.That(solution.Search("bad")).IsTrue();
        await Assert.That(solution.Search(".ad")).IsTrue();
        await Assert.That(solution.Search("b..")).IsTrue();
    }
}
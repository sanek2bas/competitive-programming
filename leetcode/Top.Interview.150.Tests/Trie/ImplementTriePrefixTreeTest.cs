using Top.Interview._150.Trie;

namespace Trie;

public class ImplementTriePrefixTreeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task ImplementTriePrefixTree(IList<(TrieCommands, string)> words, IList<bool?> answer)
    {
        var solution = new ImplementTriePrefixTree();
        IList<bool?> result = solution.Execute(words);
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(IList<(TrieCommands, string)> words, IList<bool?> answer)> DataSource()
    {
          yield return (
            new (TrieCommands, string)[]
                {
                    (TrieCommands.Insert, "apple"),
                    (TrieCommands.Search, "apple"),
                    (TrieCommands.Search, "app"),
                    (TrieCommands.StartsWith, "app"),
                    (TrieCommands.Insert, "app"),
                    (TrieCommands.Search, "app")
                },
            new bool?[] { null, true, false, true, null, true });
    }
}
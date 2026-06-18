using Top.Interview._150.Common;
using Top.Interview._150.Trie;

namespace Trie;

public class WordSearch2Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(char[][] board, string[] words, IList<string> answer)
    {
        var solution = new WordSearch2();

        var result = solution.Execute(board, words);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(char[][] board, string[] words, IList<string> answer)> DataSource()
    {
        yield return (
            [
                ['a', 'b'],
                ['c', 'd']
            ],
            ["abcb"],
            []);
        
        yield return (
            [
                ['o', 'a', 'a', 'n'],
                ['e', 't', 'a', 'e'],
                ['i', 'h', 'k', 'r'],
                ['i', 'f', 'l', 'v']
            ],
            ["oath","pea","eat","rain"],
            ["eat","oath"]);
    }
}
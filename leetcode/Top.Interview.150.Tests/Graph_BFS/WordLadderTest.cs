using Top.Interview._150.Graph_BFS;

namespace Graph_BFS;

public class WordLadderTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string beginWord, string endWord, IList<string> wordList, int answer)
    {
        var solution = new WordLadder();

        var result = solution.Execute(beginWord, endWord, wordList);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(string beginWord, string endWord, IList<string> wordList, int answer)> DataSource()
    {
        yield return (
            "hit",
            "cog",
            ["hot", "dot", "dog", "lot", "log", "cog"],
            5
        );

        yield return (
            "hit",
            "cog",
            ["hot", "dot", "dog", "lot", "log"],
            0
        );
    }
}
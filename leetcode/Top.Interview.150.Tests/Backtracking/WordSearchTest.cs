using Top.Interview._150.Backtracking;

namespace Backtracking;

public class WordSearchTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(char[][] board, string word, bool answer)
    {
        var solution = new WordSearch();

        var result = solution.Execute(board, word);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(char[][] board, string word, bool answer)> DataSource()
    {
        yield return (
            new char[][]
            {
                ['A', 'B', 'C', 'E'],
                ['S', 'F', 'C', 'S'],
                ['A', 'D', 'E', 'E']
            },
            "ABCCED", true);
        
        yield return (
            new char[][]
            {
                ['A', 'B', 'C', 'E'],
                ['S', 'F', 'C', 'S'],
                ['A', 'D', 'E', 'E']
            },
            "SEE", true);
        
        yield return (
            new char[][]
            {
                ['A', 'B', 'C', 'E'],
                ['S', 'F', 'C', 'S'],
                ['A', 'D', 'E', 'E']
            },
            "ABCB", false);
    }
}
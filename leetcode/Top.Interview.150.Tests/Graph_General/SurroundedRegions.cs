using Top.Interview._150.Graph_General;

namespace Graph_General;

public class SurroundedRegionsTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(char[][] board, char[][] answer)
    {
        var solution = new SurroundedRegions();
        
        solution.Execute(board);
        
        await Assert.That(board).IsEquivalentTo(answer);
    }

    public IEnumerable<(char[][] board, char[][] answer)> DataSource()
    {
         yield return (
            new char[][]
            {
                ['X', 'X', 'X', 'X'], 
                ['X', 'O', 'O', 'X'], 
                ['X', 'X', 'O', 'X'], 
                ['X', 'O', 'X', 'X'], 
            }, 
            new char[][]
            {
                ['X', 'X', 'X', 'X'], 
                ['X', 'X', 'X', 'X'], 
                ['X', 'X', 'X', 'X'], 
                ['X', 'O', 'X', 'X']
            });
        yield return (
            new char[][]
            {
                ['X']
            },
            new char[][]
            {
                ['X']
            });
    }
}
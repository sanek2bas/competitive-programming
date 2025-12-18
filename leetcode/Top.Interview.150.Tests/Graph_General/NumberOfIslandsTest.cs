using Top.Interview._150.Graph_General;

namespace Graph_General;

public class NumberOfIslandsTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(char[][] grid, int answer)
    {
        var solution = new NumberOfIslands();
        
        var result = solution.Execute(grid);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }
    public IEnumerable<(char[][] grid, int answer)> DataSource()
    {
         yield return (
            new char[][]
            {
                ['1', '1', '1', '1', '0'], 
                ['1', '1', '0', '1', '0'], 
                ['1', '1', '0', '0', '0'], 
                ['0', '0', '0', '0', '0'], 
            }, 
            1);
        yield return (
            new char[][]
            {
                ['1', '1', '0', '0', '0'],
                ['1', '1', '0', '0', '0'],
                ['0', '0', '1', '0', '0'],
                ['0', '0', '0', '1', '1'],
            },
            3);
    }
}
using Top.Interview._150.Backtracking;

namespace Backtracking;

public class CombinationTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Combination(int n, int k, IList<IList<int>> answer)
    {
        var solution = new Combination();
        var result = solution.Execute(n, k);
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int n, int k, IList<IList<int>> answer)> DataSource()
    {
        yield return (4, 2,
            new List<IList<int>>
            {
                new List<int> { 1, 2 },
                new List<int> { 1, 3 },
                new List<int> { 1, 4 },
                new List<int> { 2, 3 },
                new List<int> { 2, 4 },
                new List<int> { 3, 4 }
            });
        yield return (1, 1, 
            new List<IList<int>> 
            { 
                new List<int> { 1 } 
            });
    }
}
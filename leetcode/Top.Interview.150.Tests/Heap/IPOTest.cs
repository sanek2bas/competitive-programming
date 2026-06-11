using Top.Interview._150.Heap;

namespace Heap;

public class IPOTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int k, int w, int[] profits, int[] capital, int answer)
    {
        var solution = new IPO();

        var result = solution.Execute(k, w, profits, capital);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int k, int w, int[] profits, int[] capital, int answer)> DataSource()
    {
        yield return (
            2, 0,
            new int[] {1, 2, 3},
            new int [] {0, 1, 1},
            4);
        
         yield return (
            3, 0,
            new int[] {1, 2, 3},
            new int [] {0, 1, 2},
            6);
    }
}
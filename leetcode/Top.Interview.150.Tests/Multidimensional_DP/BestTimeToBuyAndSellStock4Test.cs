using Top.Interview._150.Multidimensional_DP;

namespace Multidimensional_DP;

public class BestTimeToBuyAndSellStock4Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int k, int[] prices, int answer)
    {
        var solution = new BestTimeToBuyAndSellStock4();

        var result = solution.Execute(k, prices);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int k, int[] prices, int answer)> DataSource()
    {
        yield return (2, [2, 4, 1], 2);
        yield return (2, [3, 2, 6, 5, 0, 3], 7);
    }
}
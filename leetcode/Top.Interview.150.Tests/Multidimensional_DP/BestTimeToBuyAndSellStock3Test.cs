using Top.Interview._150.Multidimensional_DP;

namespace Multidimensional_DP;

public class BestTimeToBuyAndSellStock3Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] prices, int answer)
    {
        var solution = new BestTimeToBuyAndSellStock3();

        var result = solution.Execute(prices);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] prices, int answer)> DataSource()
    {
        yield return ([3, 3, 5, 0, 0, 3, 1, 4], 6);
        yield return ([1, 2, 3, 4, 5], 4);
        yield return ([7, 6, 4, 3, 1], 0);
    }
}
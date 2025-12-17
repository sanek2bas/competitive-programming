using Top.Interview._150.Dynamic_Programming;

namespace Dynamic_Programming;

public class BestTimeToBuyAndSellStockTest
{
    [Test]
    [Arguments(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [Arguments(new int[] { 7, 6, 4, 3, 1 }, 0)]
    public async Task Solution(int[] prices, int answer)
    {
        var solution = new BestTimeToBuyAndSellStock();

        var result = solution.Execute(prices);

        await Assert.That(result).IsEqualTo(answer);
    }
}
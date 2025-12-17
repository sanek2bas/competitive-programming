using Top.Interview._150.Dynamic_Programming;

namespace Dynamic_Programming;

public class BestTimeToBuyAndSellStock2Test
{
    [Test]
    [Arguments(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
    [Arguments(new int[] { 1, 2, 3, 4, 5  }, 4)]
    [Arguments(new int[] { 7, 6, 4, 3, 1  }, 0)]
    public async Task Solution(int[] prices, int answer)
    {
        var solution = new BestTimeToBuyAndSellStock2();

        var result = solution.Execute(prices);

        await Assert.That(result).IsEqualTo(answer);
    }
}
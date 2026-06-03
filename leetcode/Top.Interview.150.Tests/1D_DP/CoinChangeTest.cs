using Top.Interview._150._1D_DP;

namespace _1D_DP;

public class CoinChangeTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] coins, int amount, int answer)
    {
        var solution = new CoinChange();

        var result = solution.Execute(coins, amount);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] coins, int amount, int answer)> DataSource()
    {
        yield return ([1, 2, 5], 11, 3);
        yield return ([2], 3, -1);
        yield return ([1], 0, 0);
    }
}

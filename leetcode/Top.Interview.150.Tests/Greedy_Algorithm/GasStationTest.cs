using Top.Interview._150.Greedy_Algorithm;

namespace Greedy_Algorithm;

public class GasStationTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] gas, int[] cost, int answer)
    {
        var solution = new GasStation();
        var result = solution.Execute(gas, cost);
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] gas, int[] cost, int answer)> DataSource()
    {
         yield return (
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 3, 4, 5, 1, 2 },
            3);
        yield return (
            new int[] { 2, 3, 4 },
            new int[] { 3, 4, 3 },
            -1);
    }
}
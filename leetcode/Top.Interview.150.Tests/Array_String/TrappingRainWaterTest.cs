using Top.Interview._150.Array_String;

namespace Array_String;

public class TrappingRainWaterTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] ratings, int answer)
    {
        var solution = new TrappingRainWater();

        var result = solution.Execute(ratings);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] ratings, int answer)> DataSource()
    {
        yield return (
            new int[] {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1},
            6
        );

        yield return (
            new int[] {4, 2, 0, 3, 2, 5},
            9
        );
    }
}
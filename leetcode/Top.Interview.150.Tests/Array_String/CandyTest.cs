using Top.Interview._150.Array_String;

namespace Array_String;

public class CandyTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] ratings, int answer)
    {
        var solution = new Candy();

        var result = solution.Execute(ratings);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] ratings, int answer)> DataSource()
    {
        yield return (
            new int[] {1, 0, 2},
            5
        );

        yield return (
            new int[] {1, 2, 2},
            4
        );
    }
}
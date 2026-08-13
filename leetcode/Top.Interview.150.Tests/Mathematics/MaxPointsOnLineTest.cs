using Top.Interview._150.Mathematics;

namespace Mathematics;

public class MaxPointsOnLineTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[][] points, int answer)
    {
        var solution = new MaxPointsOnLine();

        var result = solution.Execute(points);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[][] points, int answer)> DataSource()
    {
        yield return (
            [[1,1], [2,2], [3,3]],
            3);

        yield return (
            [[1,1], [3,2], [5,3], [4,1], [2,3], [1,4]],
            4);
    }
}
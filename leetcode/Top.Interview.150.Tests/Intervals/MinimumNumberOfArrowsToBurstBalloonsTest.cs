using Top.Interview._150.Intervals;

namespace Intervals;

public class MinimumNumberOfArrowsToBurstBalloonsTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[][] points, int answer)
    {
        var solution = new MinimumNumberOfArrowsToBurstBalloons();
        
        var result = solution.Execute(points);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[][] points, int answer)> DataSource()
    {
        yield return (
            new int[][] 
            {
                [10,16], [2,8], [1,6], [7,12] 
            },
            2);

        yield return (
            new int[][] 
            { 
                [1,2], [3,4], [5,6], [7,8]
            },
            4);
        
        yield return (
            new int[][] 
            { 
                [1,2], [2,3], [3,4], [4,5]
            },
            2);
    }
}
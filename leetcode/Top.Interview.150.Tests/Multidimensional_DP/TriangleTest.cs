using Top.Interview._150.Multidimensional_DP;

namespace Multidimensional_DP;

public class TriangleTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(IList<IList<int>> triangle, int answer)
    {
        var solution = new Triangle();

        var result = solution.Execute(triangle);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(IList<IList<int>> triangle, int answer)> DataSource()
    {
         yield return (
            new List<IList<int>> 
            { 
                new List<int> { 2 },
                new List<int> { 3, 4 },
                new List<int> { 6, 5, 7 },
                new List<int> { 4, 1, 8, 3 }
            }, 11);
        yield return (
            new List<IList<int>> 
            { 
                new List<int> { -10 }
            }, -10);
    }
}
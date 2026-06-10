using Top.Interview._150.Heap;

namespace Heap;

public class FindMedianFromDataStreamTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(IList<(string key, int num)> commands, IList<double?> answer)
    {
        var solution = new FindMedianFromDataStream();

        var result = solution.Execute(commands);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(IList<(string key, int num)> commands, IList<double?> answer)> DataSource()
    {
        yield return (
            new List<(string key, int num)>
            {
                ("addNum", 1),
                ("addNum", 2),
                ("findMedian", -1),
                ("addNum", 3),
                ("findMedian", -1)
            },
            new List<double?>
            {
                null, null, null, 1.5, null, 2.0
            }
        );
    }
}
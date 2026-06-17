using Top.Interview._150.Binary_Search;

namespace Binary_Search;

public class FindFirstAndLastPositionOfElementInSortedArrayTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, int target, int[] answer)
    {
        var solution = new FindFirstAndLastPositionOfElementInSortedArray();

        var result = solution.Execute(nums, target);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[] nums, int target, int[] answer)> DataSource()
    {
        yield return (
            [5, 7, 7, 8, 8, 10],
            8,
            [3, 4]);
        
        yield return (
            [5, 7, 7, 8, 8, 10],
            6,
            [-1, -1]);
        
        yield return (
            [],
            0,
            [-1, -1]);
    }
}
using Top.Interview._150.Hashmap;

namespace Hashmap;

public class TwoSumTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, int target, int[] answer)
    {
        var solution = new TwoSum();

        var result = solution.Execute(nums, target);

        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[] nums, int target, int[] answer)> DataSource()
    {
        yield return (
            new int[] { 2, 7, 11, 15 }, 
            9, 
            new int[] { 0, 1 });
        yield return (
            new int[] { 3, 2, 4 }, 
            6, 
            new int[] { 1, 2 });
        yield return (
            new int[] { 3, 3 },
            6, 
            new int[] { 0, 1 });
    }
}
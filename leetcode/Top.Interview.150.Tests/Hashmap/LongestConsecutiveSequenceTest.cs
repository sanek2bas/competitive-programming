using Top.Interview._150.Hashmap;

namespace Hashmap;

public class LongestConsecutiveSequenceTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, int answer)
    {
        var solution = new LongestConsecutiveSequence();

        var result = solution.Execute(nums);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] nums, int answer)> DataSource()
    {
        yield return (
            new int[] { 100, 4, 200, 1, 3, 2 }, 
            4);
        yield return (
            new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 
            9);
         yield return (
            new int[] { 1, 0, 1, 2 }, 
            3);
    }
}
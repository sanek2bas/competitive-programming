using Top.Interview._150.Heap;

namespace Heap;

public class KthLargestElementInArray_Test
{
    [Test]
    [Arguments(new int[] { 3, 2, 1, 5, 6, 4 }, 2, 5)]
    [Arguments(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
    public async Task KthLargestElementInArray(int[] nums, int k, int answer)
    {
        var solution = new KthLargestElementInArray();
        var result = solution.Execute(nums, k);
        await Assert.That(result).IsEqualTo(answer);
    }
}
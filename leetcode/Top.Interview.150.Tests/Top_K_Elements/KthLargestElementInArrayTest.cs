using Top.Interview._150.Top_K_Elements;

namespace Top_K_Elements;

public class KthLargestElementInArrayTest
{
    [Test]
    [Arguments(new int[] { 3, 2, 1, 5, 6, 4 }, 2, 5)]
    [Arguments(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
    public async Task Solution(int[] nums, int k, int answer)
    {
        var solution = new KthLargestElementInArray();

        var result = solution.Execute(nums, k);
        
        await Assert.That(result).IsEqualTo(answer);
    }
}
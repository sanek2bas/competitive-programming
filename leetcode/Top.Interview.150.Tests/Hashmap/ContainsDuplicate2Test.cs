using Top.Interview._150.Hashmap;

namespace Hashmap;

public class ContainsDuplicate2Test
{
    [Test]
    [Arguments(new int[] { 1, 2, 3, 1 }, 3, true)]
    [Arguments(new int[] { 1, 0, 1, 1 }, 1, true)]
    [Arguments(new int[] { 1, 2, 3, 1, 2, 3 }, 2, false)]
    public async Task Solution(int[] nums, int k, bool answer)
    {
        var solution = new ContainsDuplicate2();

        var result = solution.Execute(nums, k);

        await Assert.That(result).IsEqualTo(answer);
    }
}
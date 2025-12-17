using Top.Interview._150.Array_String;

namespace Array_String;

public class RemoveElementTest
{
    [Test]
    [Arguments(new int[] {3, 2, 2, 3 }, 3, 2)]
    [Arguments(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
    public async Task Solution(int[] nums, int val, int answer)
    {
        var solution = new RemoveElement();

        var result = solution.Execute(nums, val);

        await Assert.That(result).IsEqualTo(answer);
    }
}
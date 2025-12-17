using Top.Interview._150.Array_String;

namespace Array_String;

public class MajorityElementTest
{
    [Test]
    [Arguments(new int[] { 3, 2, 3 }, 3)]
    [Arguments(new int[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
    [Arguments(new int[] { 2, 2, 2, 2, 1, 1, 0, 7 }, 2)]
    public async Task Solution(int[] nums, int answer)
    {
        var solution = new MajorityElement();

        var result = solution.Execute(nums);

        await Assert.That(result).IsEqualTo(answer);
    }
}
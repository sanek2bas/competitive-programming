using Top.Interview._150.Array_String;

namespace Array_String;

public class RemoveDuplicatesFromSortedArrayTest2
{
    [Test]
    [Arguments(new int[] { 1, 1, 1, 2, 2, 3  }, 5)]
    [Arguments(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 }, 7)]
    public async Task Solution(int[] nums, int answer)
    {
        var solution = new RemoveDuplicatesFromSortedArray2();

        var result = solution.Execute(nums);

        await Assert.That(result).IsEqualTo(answer);
    }
}
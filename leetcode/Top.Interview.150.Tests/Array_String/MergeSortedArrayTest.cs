using Top.Interview._150.Array_String;

namespace Array_String;

public class MergeSortedArrayTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums1, int m, int[] nums2, int n, int[] answer)
    {
        var solution = new MergeSortedArray();

        solution.Execute(nums1, m, nums2, n);

        await Assert.That(nums1).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[] nums1, int m, int[] nums2, int n, int[] answer)> DataSource()
    {
        yield return (
            new int[] { 1, 2, 3, 0, 0, 0 }, 3,
            new int[] { 2, 5, 6 }, 3,
            new int[] { 1, 2, 2, 3, 5, 6 });
        yield return (
            new int[] { 1 }, 1,
            new int[] { }, 0,
            new int[] { 1 });
        yield return (
            new int[]{ 0 }, 0, 
            new int[] { 1 }, 1,
            new int[] { 1 });
    }
}
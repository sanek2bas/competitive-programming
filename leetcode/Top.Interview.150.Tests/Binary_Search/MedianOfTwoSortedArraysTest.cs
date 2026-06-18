using Top.Interview._150.Binary_Search;

namespace Binary_Search;

public class MedianOfTwoSortedArraysTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums1, int[] nums2, double answer)
    {
        var solution = new MedianOfTwoSortedArrays();

        var result = solution.Execute(nums1, nums2);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] nums1, int[] nums2, double answer)> DataSource()
    {
        yield return (
            [1, 3],
            [2],
            2.00000);
        
        yield return (
            [1, 2],
            [3, 4],
            2.50000);
    }
}
using Top.Interview._150.Heap;

namespace Heap;

public class FindKPairsWithSmallestSumsTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums1, int[] nums2, int k, IList<IList<int>> answer)
    {
        var solution = new FindKPairsWithSmallestSums();

        var result = solution.Execute(nums1, nums2, k);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[] nums1, int[] nums2, int k, IList<IList<int>> answer)> DataSource()
    {
        yield return (
            [1, 7, 11],
            [2, 4, 6],
            3,
            new List<IList<int>>()
            {
                new List<int> { 1, 2 },
                new List<int>() { 1, 4 },
                new List<int>() { 1, 6 }
            });

        yield return (
            [1, 1, 2],
            [1, 2, 3],
            2,
            new List<IList<int>>()
            {
                new List<int> { 1, 1 },
                new List<int>() { 1, 1 }
            });
    }
}
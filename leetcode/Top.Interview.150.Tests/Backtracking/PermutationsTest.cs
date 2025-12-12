using Top.Interview._150.Backtracking;

namespace Backtracking;

public class PermutationTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, IList<IList<int>> answer)
    {
        var solution = new Permutation();

        var result = solution.Execute(nums);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[] nums, IList<IList<int>> answer)> DataSource()
    {
        yield return (
            new int[] { 1, 2, 3 },
            new List<IList<int>>()
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 1, 3, 2 },
                new List<int> { 2, 1, 3 },
                new List<int> { 2, 3, 1 },
                new List<int> { 3, 1, 2 },
                new List<int> { 3, 2, 1 }
            });
        yield return (
            new int[] { 0, 1 },
            new List<IList<int>>()
            {
                new List<int> { 0, 1 },
                new List<int> { 1, 0 }
            });
        yield return (
            new int[] { 1 },
            new List<IList<int>>()
            {
                new List<int> { 1 }
            });
    }
}
using Top.Interview._150.Two_Pointers;

namespace Two_Pointers;

public class ThreeSumTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, IList<IList<int>> answer)
    {
        var solution = new ThreeSum();

        var result = solution.Execute(nums);

        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[] nums, IList<IList<int>> answer)> DataSource()
    {
        yield return 
            ([-1, 0, 1, 2, -1, -4],
            [[-1, -1, 2], [-1, 0, 1]]);
        
        yield return 
            ([0, 1, 1], 
            []);
        
        yield return 
            ([0, 0, 0], 
            [[0, 0, 0]]);
    }
}
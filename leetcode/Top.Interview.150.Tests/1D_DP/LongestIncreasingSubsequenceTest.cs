using Top.Interview._150._1D_DP;

namespace _1D_DP;

public class LongestIncreasingSubsequenceTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, int answer)
    {
         var solution = new LongestIncreasingSubsequence();

        var result = solution.Execute(nums);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] digits, int answer)> DataSource()
    {
        yield return ([10, 9, 2, 5, 3, 7, 101, 18], 4);
        yield return ([0, 1, 0, 3, 2, 3], 4);
        yield return ([7, 7, 7, 7, 7, 7, 7], 1);
        yield return ([2, 4, 5, 3, 9, 10 ], 5);
    }
}
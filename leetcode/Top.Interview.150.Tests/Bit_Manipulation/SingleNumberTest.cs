using Top.Interview._150.Bit_Manipulation;

namespace Bit_Manipulation;

public class SingleNumberTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, int answer)
    {
        var solution = new SingleNumber();
        var result = solution.Execute(nums);
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] nums, int answer)> DataSource()
    {
        yield return (
            new int[] { 2, 2, 1 },
            1);
        yield return (
            new int[] { 4, 1, 2, 1, 2 },
            4);
        yield return (
            new int[] { 1 }, 
            1);
    }
}
using Top.Interview._150.Bit_Manipulation;

namespace Bit_Manipulation;

public class SingleNumber2Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] nums, int answer)
    {
        var solution = new SingleNumber2();

        var result = solution.Execute(nums);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] nums, int answer)> DataSource()
    {
        yield return (
            new int[] { 2, 2, 3, 2 },
            3);
        yield return (
            new int[] { 0, 1, 0, 1, 0, 1, 99 },
            99);
    }
}
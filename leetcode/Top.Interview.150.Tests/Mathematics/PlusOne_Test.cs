using Top.Interview._150.Mathematics;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace Mathematics;

public class PlusOne_Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task PlusOne(int[] digits, int[] answer)
    {
        var solution = new PlusOne();
        var result = solution.Execute(digits);
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[] digits, int[] answer)> DataSource()
    {
        yield return (
            new int[] { 1, 2, 3 },
            new int[] { 1, 2, 4 });
        yield return (
           new int[] { 4, 3, 2, 1 },
           new int[] { 4, 3, 2, 2 });
        yield return (
           new int[] { 9 },
           new int[] { 1, 0 });
    }
}
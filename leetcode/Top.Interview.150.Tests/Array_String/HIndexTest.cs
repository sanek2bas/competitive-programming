using Top.Interview._150.Array_String;

namespace Array_String;

public class HIndexTest
{
    [Test]
    [Arguments(new int[] { 3, 0, 6, 1, 5 }, 3)]
    [Arguments(new int[] { 1, 3, 1 }, 1)]
    public async Task Solution(int[] citations, int answer)
    {
        var solution = new HIndex();

        var result = solution.Execute(citations);

        await Assert.That(result).IsEqualTo(answer);
    }
}
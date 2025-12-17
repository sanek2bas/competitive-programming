using Top.Interview._150.Array_String;

namespace Array_String;

public class LongestCommonPrefixTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string[] strs, string answer)
    {
        var solution = new LongestCommonPrefix();

        var result = solution.Execute(strs);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(string[] strs, string answer)> DataSource()
        {
            yield return (
                new string[] { "flower", "flow", "flight" },
                "fl");
            yield return (
                new string[] { "dog", "racecar", "car" },
                "");
        }
}
using Top.Interview._150.HashMap;

namespace HashMap;

public class GroupAnagramsTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string[] strs, IList<IList<string>> answer)
    {
        var solution = new GroupAnagrams();
        var result = solution.Execute(strs);
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(string[] strs, IList<IList<string>> answer)> DataSource()
    {
        yield return (
            new string[] { "eat", "tea", "tan", "ate", "nat", "bat" },
            new List<IList<string>>
            {
                new List<string> {"eat", "tea", "ate"},
                new List<string> {"tan", "nat"},
                new List<string> {"bat"}
            });
        yield return (
            new string[] { },
            new List<IList<string>> { });
        yield return (
            new string[] { "a" },
            new List<IList<string>>
            {
                new List<string> {"a"}
            });
    }
}
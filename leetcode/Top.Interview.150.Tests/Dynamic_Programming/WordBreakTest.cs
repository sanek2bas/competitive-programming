using Top.Interview._150.Dynamic_Programming;

namespace Dynamic_Programming;

public class WordBreakTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string s, IList<string> words, bool answer)
    {
        var solution = new WordBreak();

        var result = solution.Execute(s, words);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(string s, IList<string> words, bool answer)> DataSource()
    {
        yield return (
            "leetcode",
            new List<string>() {"leet", "code"}, 
            true);
        yield return (
            "applepenapple",
            new List<string>() {"apple", "pen"}, 
            true);
        yield return (
            "catsandog",
            new List<string>() {"cats", "dog", "sand", "and", "cat"}, 
            false);
    }
}
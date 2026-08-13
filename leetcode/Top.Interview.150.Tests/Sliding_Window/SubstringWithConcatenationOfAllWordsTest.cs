using Top.Interview._150.Sliding_Window;

namespace Sliding_Window;

public class SubstringWithConcatenationOfAllWordsTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string s, string[] words, IList<int> answer)
    {
        var solution = new SubstringWithConcatenationOfAllWords();

        var result = solution.Execute(s, words);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(string s, string[] words, IList<int> answer)> DataSource()
    {
        yield return (
            "barfoothefoobarman",
            ["foo", "bar"],
            [0, 9]);

        yield return (
            "wordgoodgoodgoodbestword",
            ["word", "good", "best", "word"],
            []);
        
        yield return (
            "barfoofoobarthefoobarman",
            ["bar", "foo", "the"],
            [6, 9, 12]);
    }
}
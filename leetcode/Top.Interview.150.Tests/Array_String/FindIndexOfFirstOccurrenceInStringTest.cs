using Top.Interview._150.Array_String;

namespace Array_String;

public class FindIndexOfFirstOccurrenceInStringTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string haystack, string needle, int answer)
    {
        var solution = new FindIndexOfFirstOccurrenceInString();

        var result = solution.Execute(haystack, needle);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(string haystack, string needle, int answer)> DataSource()
    {
        yield return ("sadbutsad", "sad", 0);
        yield return ("leetcode", "leeto", -1);
    }
}
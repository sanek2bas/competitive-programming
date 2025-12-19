using Top.Interview._150.Multidimensional_DP;

namespace Multidimensional_DP;

public class InterleavingStringTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string s1, string s2, string s3, bool answer)
    {
        var solution = new InterleavingString();

        var result = solution.Execute(s1, s2, s3);

        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(string s1, string s2, string s3, bool answer)> DataSource()
    {
        yield return ("aabcc", "dbbca", "aadbbcbcac", true);
        yield return ("aabcc", "dbbca", "aadbbbaccc", false);
        yield return ("", "", "", true);
    }
}
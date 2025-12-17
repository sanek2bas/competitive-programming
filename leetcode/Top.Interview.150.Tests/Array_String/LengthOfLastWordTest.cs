using Top.Interview._150.Array_String;

namespace Array_String;

public class LengthOfLastWordTest
{
    [Test]
    [Arguments("Hello World", 5)]
    [Arguments("   fly me   to   the moon  ", 4)]
    [Arguments("luffy is still joyboy", 6)]
    public async Task Solution(string str, int answer)
    {
        var solution = new LengthOfLastWord();

        var result = solution.Execute(str);

        await Assert.That(result).IsEqualTo(answer);
    }
}
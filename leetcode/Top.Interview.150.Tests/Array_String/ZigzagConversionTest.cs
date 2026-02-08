using Top.Interview._150.Array_String;

namespace Array_String;

public class ZigzagConversionTest
{
    [Test]
    [Arguments("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [Arguments("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [Arguments("A", 1, "A")]
    public async Task Solution(string s, int numRows, string answer)
    {
        var solution = new ZigzagConversion();

        var result = solution.Execute(s, numRows);

        await Assert.That(result).IsEqualTo(answer);
    }
}
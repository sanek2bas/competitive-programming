using Top.Interview._150.Stack;

namespace Stack;

public class BasicCalculatorTest
{
    [Test]
    [Arguments("1 + 1", 2)]
    [Arguments(" 2-1 + 2 ", 3)]
    [Arguments("(1+(4+5+2)-3)+(6+8)", 23)]
    [Arguments("-(3-(4+5))", 6)]
    public async Task Solution(string str, int answer)
    {
        var solution = new BasicCalculator();
        var result = solution.Execute(str);
        await Assert.That(result).IsEqualTo(answer);
    }
}
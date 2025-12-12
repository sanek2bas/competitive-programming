using Top.Interview._150.Stack;

namespace Stack;

public class ValidParenthesesTest
{
    [Test]
    [Arguments("()", true)]
    [Arguments("()[]{}", true)]
    [Arguments("(]", false)]
    public async Task Solution(string str, bool answer)
    {
        var solution = new ValidParentheses();
        
        var result = solution.Execute(str);

        await Assert.That(result).IsEqualTo(answer);
    }
}
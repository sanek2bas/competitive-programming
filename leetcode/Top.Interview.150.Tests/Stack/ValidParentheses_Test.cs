using Top.Interview._150.Stack;
namespace Stack;

public class ValidParentheses_Test
{
    [Test]
    [Arguments("()", true)]
    [Arguments("()[]{}", true)]
    [Arguments("(]", false)]
    public async Task ValidParentheses(string str, bool answer)
    {
        var solution = new ValidParentheses();
        var result = solution.Execute(str);
        await Assert.That(result).IsEqualTo(answer);
    }
}
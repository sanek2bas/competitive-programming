using Top.Interview._150.Stack;

namespace Stack;

public class ValidParentheses_Test
{
    [Test]
    [Arguments("1 + 1", 2)]
    [Arguments(" 2-1 + 2 ", 3)]
    [Arguments("(1+(4+5+2)-3)+(6+8)", 23)]
    [Arguments("-(3-(4+5))", 6)]
    public void ValidParentheses(string str, int answer)
    {
        var solution = new ValidParentheses();
        var result = solution.Execute(str);
        Equals(result, answer);
    }
}
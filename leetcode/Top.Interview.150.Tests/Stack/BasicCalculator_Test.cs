using Top.Interview._150.Stack;

namespace Stack;

public class BasicCalculator_Test
{
    [Test]
    [Arguments("()", true)]
    [Arguments("()[]{}", true)]
    [Arguments("(]", false)]
    public void BasicCalculator(string str, bool answer)
    {
        var solution = new BasicCalculator();
        var result = solution.Execute(str);
        Equals(result, answer);
    }
}
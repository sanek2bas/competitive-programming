namespace Top.Interview._150.Stack;

public class EvaluateReversePolishNotation
{
    /// <summary>
    /// # 150
    /// https://leetcode.com/problems/evaluate-reverse-polish-notation/description/
    /// You are given an array of strings tokens that represents an arithmetic
    /// expression in a Reverse Polish Notation.
    /// Evaluate the expression. Return an integer that represents the value 
    /// of the expression. 
    /// Note that:
    /// The valid operators are '+', '-', '*', and '/'.
    /// Each operand may be an integer or another expression.
    /// The division between two integers always truncates toward zero.
    /// There will not be any division by zero.
    /// The input represents a valid arithmetic expression in a reverse polish notation.
    /// The answer and all the intermediate calculations can be represented in a 32-bit integer.
    /// </summary>
    public int Execute(string[] tokens)
    {
        var op = new Dictionary<string, Func<long, long, long>> 
        {
            ["+"] = (a, b) => a + b,
            ["-"] = (a, b) => a - b,
            ["*"] = (a, b) => a * b,
            ["/"] = (a, b) => a / b
        };
        
        var stack = new Stack<long>();

        foreach (var token in tokens) 
        {
            if (op.ContainsKey(token)) 
            {
                long b = stack.Pop();
                long a = stack.Pop();
                stack.Push(op[token](a, b));
            } 
            else
            {
                stack.Push(long.Parse(token));
            }
        }

        return (int)stack.Pop();
    }
}
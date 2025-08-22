namespace Top.Interview._150.Stack;

public class BasicCalculator
{
    /// <summary>
    /// # 224
    /// https://leetcode.com/problems/basic-calculator/description/
    /// Given a string s representing a valid expression, 
    /// implement a basic calculator to evaluate it, 
    /// and return the result of the evaluation.
    /// Note: You are not allowed to use any built-in function 
    /// which evaluates strings as mathematical expressions, such as eval().
    /// </summary>
    public int Execute(string s)
    {
        int answer = 0;
        int sign = 1;
        var signStack = new Stack<int>();
        int number = 0;

        foreach (var ch in s)
        {
            if (char.IsDigit(ch))
            {
                number = number * 10 + (int)char.GetNumericValue(ch);
            }
            else if (ch == '(')
            {
                signStack.Push(sign);
            }
            else if (ch == ')') 
            {
                if (signStack.Count > 0)
                    signStack.Pop();
            }
            else if (ch == '-' || ch == '+')
            {
                answer += number * sign;
                sign = (ch == '+' ? 1 : -1) *
                    (signStack.Count > 0 ? signStack.Peek() : 1);
                number = 0;
            }
        }
        answer += number * sign;
        return answer;
    }
}
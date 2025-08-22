namespace Top.Interview._150.Stack;

public class ValidParentheses
{
    /// <summary>
    /// # 20
    /// https://leetcode.com/problems/valid-parentheses/description/
    /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']',
    ///  determine if the input string is valid.
    /// An input string is valid if:
    /// 1. Open brackets must be closed by the same type of brackets.
    /// 2. Open brackets must be closed in the correct order.
    /// 3. Every close bracket has a corresponding open bracket of the same type.
    /// </summary>
    public bool Execute(string s)
    {
        var stack = new Stack<char>();
        foreach (char ch in s)
        {
            if (ch == '(' || ch == '[' || ch == '{')
            {
                stack.Push(ch);
                continue;
            }

            if (stack.Count == 0)
                return false;

            var prevCh = stack.Pop();
            if (prevCh == '(' && ch == ')')
                continue;
            if (prevCh == '[' && ch == ']')
                continue;
            if (prevCh == '{' && ch == '}')
                continue;

            return false;
        }

        return stack.Count == 0;
    }
}
namespace Interview.Queue_Stack
{
    public static class ValidParentheses
    {
        /// <summary>
        /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        /// An input string is valid if:
        /// Open brackets must be closed by the same type of brackets.
        /// Open brackets must be closed in the correct order.
        /// Every close bracket has a corresponding open bracket of the same type.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Execute(string str)
        {
            var stack = new Stack<char>();
            foreach (char c in str)
            {
                if(c == '(' || 
                   c == '[' || 
                   c == '{')
                {
                    stack.Push(c);
                    continue;
                }
                
                if (stack.Count == 0)
                    return false;

                var prevC = stack.Pop();
                if (prevC == '(' && c == ')' ||
                    prevC == '[' && c == ']' ||
                    prevC == '{' && c == '}')
                    continue;

                return false;
            }
            return stack.Count == 0;
        }

        public static IEnumerable<(string str, bool answer)> GetTests()
        {
            yield return ("()", true);
            yield return ("()[]{}", true);
            yield return ("(]", false);

        }
    }
}

namespace Top.Interview._150.Backtracking;

public class GenerateParentheses
{
    /// <summary>
    /// # 22
    /// https://leetcode.com/problems/generate-parentheses/description/
    /// Given n pairs of parentheses, write a function to 
    /// generate all combinations of well-formed parentheses.
    /// </summary>
    public IList<string> Execute(int n)
    {
        var result = new List<string>();
        Generate(result, string.Empty, n, 0, 0);
        return result;
    }

    private void Generate(IList<string> result, string str, int n, int left, int right)
    {
        if (left == n
            && right == n)
        {
            result.Add(str);
            return;
        }

        if (left < n)
            Generate(result, str + "(", n, left + 1, right);

        if (right < left)
            Generate(result, str + ")", n, left, right + 1);
    }
}
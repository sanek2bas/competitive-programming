namespace Top.Interview._150.Backtracking;
using System.Text;

public class LetterCombinationsOfPhoneNumber
{
    /// <summary>
    /// # 17
    /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
    /// Given a string containing digits from 2-9 inclusive, 
    /// return all possible letter combinations that the number could represent.
    /// Return the answer in any order.
    /// A mapping of digits to letters(just like on the telephone buttons) 
    /// is given below.Note that 1 does not map to any letters.
    /// </summary>
    public IList<string> Execute(string digits)
    {
        var dic = new string[] {
            "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        var result = new List<string>();
        dfs(digits, 0, dic, result, new StringBuilder());
        return result;
    }

    private void dfs(string digits,
                     int idx,
                     string[] dic,
                     IList<string> results,
                     StringBuilder result)
    {
        if (digits.Length == idx)
        {
            if (result.Length > 0)
                results.Add(result.ToString());
            return;
        }

        var digit = digits[idx];
        var dicIdx = (int)char.GetNumericValue(digit);
        foreach (char ch in dic[dicIdx])
        {
            result.Append(ch);
            dfs(digits, idx + 1, dic, results, result);
            result.Remove(result.Length - 1, 1);
        }
    }
}
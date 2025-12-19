using System.Text;

namespace TopInterview150.Bit_Manipulation;

public class AddBinary
{
    /// <summary>
    /// # 67
    /// https://leetcode.com/problems/add-binary/description/
    /// Given two binary strings a and b, return their sum as a binary string.
    /// </summary>
    public string Execute(string a, string b)
    {
        var answer = new StringBuilder();
        int carry = 0;
        int aIdx = a.Length - 1;
        int bIdx = b.Length - 1;
        while(aIdx >= 0 || bIdx >= 0 || carry > 0)
        {
            if (aIdx >= 0)
                carry += a[aIdx--] - '0';
            if (bIdx >= 0)
                carry += b[bIdx--] - '0';
            answer.Append(carry % 2);
            carry /= 2;
        }

        var answerCharArray = answer.ToString().ToCharArray();
        Array.Reverse(answerCharArray);
        return new string(answerCharArray);
    }
}

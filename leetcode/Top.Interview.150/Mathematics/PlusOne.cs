namespace Top.Interview._150.Mathematics;

public class PlusOne
{
    /// <summary>
    /// # 66
    /// https://leetcode.com/problems/plus-one/description/
    /// You are given a large integer represented as an integer array digits, 
    /// where each digits[i] is the ith digit of the integer. 
    /// The digits are ordered from most significant to least significant in left-to-right order. 
    /// The large integer does not contain any leading 0's.
    /// Increment the large integer by one and return the resulting array of digits.
    /// </summary>
    public int[] Execute(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] == 9)
            {
                digits[i] = 0;
                continue;
            }
            digits[i]++;
            return digits;
        }

        int[] answer = new int[digits.Length + 1];
        answer[0] = 1;
        return answer;
    }
}

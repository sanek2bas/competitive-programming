namespace Top.Interview._150.Bit_Manipulation;

public class NumberOf1Bits
{
    /// <summary>
    /// # 191
    /// https://leetcode.com/problems/number-of-1-bits/description/
    /// Write a function that takes the binary representation of an 
    /// unsigned integer and returns the number of '1' bits 
    /// it has (also known as the Hamming weight).
    /// </summary>
    public int Execute(uint n)
    {
        //return BitOperations.PopCount(n);
        int answer = 0;
        foreach(int i in Enumerable.Range(0, 32))
        {
            if (((n >> i) & 1) == 1)
                answer++;
        }
        return answer;

    }
}

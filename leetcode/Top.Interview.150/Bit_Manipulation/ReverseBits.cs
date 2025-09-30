namespace Top.Interview._150.Bit_Manipulation;

public class ReverseBits
{
    /// <summary>
    /// # 190
    /// https://leetcode.com/problems/reverse-bits/
    /// Reverse bits of a given 32 bits signed integer.
    /// </summary>
    public uint Execute(uint n)
    {
        uint answer = 0;
        for(int i = 0; i < 32; i++)
        {
            uint bit = (n >> i) & 1;
            answer |= bit << (31 - i);
        }
        return answer;
    }
}
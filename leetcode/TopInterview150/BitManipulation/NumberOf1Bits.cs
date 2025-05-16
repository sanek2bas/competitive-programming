using System.Data;
using System.Numerics;

namespace TopInterview150.BitManipulation;

public static class NumberOf1Bits
{
    /// <summary>
    /// Write a function that takes the binary representation of an unsigned integer and returns the number of '1' bits 
    /// it has (also known as the Hamming weight).
    /// </summary>
    public static int Execute(uint n)
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

        public static IEnumerable<(uint n, int answer)> GetTests()
        {
            yield return (11, 3);
            yield return (128, 1);
            yield return (4_294_967_293, 31);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
}

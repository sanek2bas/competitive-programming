namespace TopInterview150.BitManipulation;

public static class ReverseBits
{
    /// <summary>
    /// Given two binary strings a and b, return their sum as a binary string.
    /// </summary>
    public static uint Execute(uint n)
    {
        uint answer = 0;
        for(int i = 0; i < 32; i++)
        {
            uint bit = (n >> i) & 1;
            answer |= bit << (31 - i);
        }
        return answer;
    }

        public static IEnumerable<(uint n, uint answer)> GetTests()
        {
            yield return (43261596, 964176192);
            yield return (4294967293, 3221225471 );
        }

        public static bool CheckResult(uint result, uint answer)
        {
            return result == answer;
        }
}

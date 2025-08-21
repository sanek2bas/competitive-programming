using System.Text;

namespace TopInterview150.BitManipulation
{
    public static class AddBinary
    {
        /// <summary>
        /// Given two binary strings a and b, return their sum as a binary string.
        /// </summary>
        public static string Execute(string a, string b)
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

        public static IEnumerable<(string a, string b, string answer)> GetTests()
        {
            yield return ("11", "1", "100");
            yield return ("1010", "1011", "10101");
        }

        public static bool CheckResult(string result, string answer)
        {
            return result == answer;
        }
    }
}

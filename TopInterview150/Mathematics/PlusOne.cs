namespace TopInterview150.Mathematics
{
    public static class PlusOne
    {
        /// <summary>
        /// You are given a large integer represented as an integer array digits, 
        /// where each digits[i] is the ith digit of the integer. 
        /// The digits are ordered from most significant to least significant in left-to-right order. 
        /// The large integer does not contain any leading 0's.
        /// Increment the large integer by one and return the resulting array of digits.
        /// </summary>
        public static int[] Execute(int[] digits)
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

        public static IEnumerable<(int[] digits, int[] answer)> GetTests()
        {
            yield return (
                new int[] { 1, 2, 3 },
                new int[] { 1, 2, 4 });
            yield return (
                new int[] { 4, 3, 2, 1 },
                new int[] { 4, 3, 2, 2 });
            yield return (
                new int[] { 9 },
                new int[] { 1, 0 });
        }

        public static bool CheckResult(int[] result, int[] answer)
        {
            if(result.Length != answer.Length)
                return false;
            return result.SequenceEqual(answer);
        }
    }
}

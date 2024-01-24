namespace Multitrack
{
    public static class TimePalindrome
    {
        /// <summary>
        /// </summary>
        public static int Execute(int n, int m)
        {
            int big = n;
            int small = m;
            if(m > n)
            {
                big = m;
                small = n;
            }

            int symbols = 0;
            int bigCopy = big;
            while(bigCopy > 0)
            {
                symbols++;
                bigCopy /= 10;
            }

            var array = new int[symbols];
            int answer = 1;
            for(int i = 1; i < small; i++)
            {
                int j = symbols - 1;
                while(j >= 0)
                {
                    if (array[j] == 9)
                    {
                        array[j] = 0;
                        j--;
                    }
                    else
                    {
                        array[j]++;
                        break;
                    }
                }

                int reverseNum = 0;
                for (j = symbols - 1; j >= 0; j--)
                {
                    reverseNum += array[j] * (int)Math.Pow(10, j);
                    if (reverseNum >= big)
                        break;
                }
                if (reverseNum < big)
                    answer++;
            }
            return answer;
        }

        public static IEnumerable<(int n, int m, int answer)> GetTests()
        {
            yield return (24, 60, 16);
            yield return (12, 1234, 4);
            yield return (1, 1, 1);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

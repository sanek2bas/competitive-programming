﻿namespace TopInterview150.Hashmap
{
    public static class HappyNumber
    {
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        /// A happy number is a number defined by the following process:
        /// Starting with any positive integer, replace the number by the sum of the squares of its digits.
        /// Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        /// Those numbers for which this process ends in 1 are happy.
        /// Return true if n is a happy number, and false if not.
        /// </summary>
        public static bool Execute(int n)
        {
            var map = new HashSet<int>();
            while(!map.Contains(n))
            {
                map.Add(n);
                int sum = 0;
                while (n > 0)
                {
                    sum += (int)Math.Pow(n % 10, 2);
                    n /= 10;
                }
                n = sum;
            }
            return n == 1;
        }

        public static IEnumerable<(int number, bool answer)> GetTests()
        {
            yield return (19, true);
            yield return (2, false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}

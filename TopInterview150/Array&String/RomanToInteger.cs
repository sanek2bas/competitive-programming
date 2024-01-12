﻿namespace TopInterview150.Array_String
{
    public static class RomanToInteger
    {
        /// <summary>
        /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        /// Symbol Value
        /// I - 1
        /// V - 5
        /// X - 10
        /// L - 50
        /// C - 100
        /// D - 500
        /// M - 1000
        /// For example, 2 is written as II in Roman numeral, just two ones added together. 
        /// 12 is written as XII, which is simply X + II.
        /// The number 27 is written as XXVII, which is XX + V + II.
        /// Roman numerals are usually written largest to smallest from left to right.
        /// However, the numeral for four is not IIII. Instead, the number four is written as IV.
        /// Because the one is before the five we subtract it making four. 
        /// The same principle applies to the number nine, which is written as IX.There are six instances where subtraction is used:
        /// I can be placed before V (5) and X(10) to make 4 and 9. 
        /// X can be placed before L(50) and C(100) to make 40 and 90. 
        /// C can be placed before D(500) and M(1000) to make 400 and 900.
        /// Given a roman numeral, convert it to an integer.
        /// </summary>
        public static int Execute(string s)
        {
            int result = 0;
            int curr = 0;
            int[] roman = new int[128];

            roman['I'] = 1;
            roman['V'] = 5;
            roman['X'] = 10;
            roman['L'] = 50;
            roman['C'] = 100;
            roman['D'] = 500;
            roman['M'] = 1000;

            foreach (char ch in s)
            {
                int num = roman[ch];
                if (num > curr)
                    result += num - 2 * curr;
                else
                    result += num;
                curr = num;
            }
            return result;
        }

        public static IEnumerable<(string romanNum, int answer)> GetTests()
        {
            yield return (
                "III",
                3);
            yield return (
                "LVIII",
                58);
            yield return (
                "MCMXCIV",
                1994);
        }

        public static bool CheckResult(int target, int answer)
        {
            return answer == target;
        }
    }
}

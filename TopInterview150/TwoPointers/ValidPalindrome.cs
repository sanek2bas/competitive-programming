namespace TopInterview150.TwoPointers
{
    public static class ValidPalindrome
    {
        /// <summary>
        /// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and 
        /// removing all non-alphanumeric characters, it reads the same forward and backward. 
        /// Alphanumeric characters include letters and numbers.
        /// Given a string s, return true if it is a palindrome, or false otherwise.
        /// </summary>
        public static bool Execute(string str)
        {
            int left = 0;
            int right = str.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(str[left]))
                    left++;
                while (left < right && !char.IsLetterOrDigit(str[right]))
                    right--;
                if (char.ToLower(str[left]) != char.ToLower(str[right]))
                    return false;
                left++;
                right--;
            }
            return true;
        }

        public static IEnumerable<(string str, bool answer)> GetTests()
        {
            yield return (
                "A man, a plan, a canal: Panama",
                true);
            yield return (
                "race a car",
                false);
            yield return (
                " ",
                true);
        }

        public static bool CheckResult(bool target, bool answer)
        {
            return answer == target;
        }
    }
}

using System.Data.SqlTypes;

namespace TopInterview150.Array_String
{
    public static class LengthOfLastWord
    {
        /// <summary>
        /// Given a string s consisting of words and spaces, return the length of the last word in the string.
        /// A word is a maximal substring consisting of non-space characters only.
        /// </summary>
        public static int Execute(string s)
        {
            int length = 0;
            int idx = s.Length - 1;
            while (idx >= 0 && char.IsWhiteSpace(s[idx]))
                idx--;
            while (idx >= 0 && !char.IsWhiteSpace(s[idx]))
            {
                idx--;
                length++;
            }
            return length;
        }

        public static IEnumerable<(string str, int answer)> GetTests()
        {
            yield return (
                "Hello World",
                5);
            yield return (
                "   fly me   to   the moon  ",
                4);
            yield return (
                "luffy is still joyboy",
                6);
        }

        public static bool CheckResult(int target, int answer)
        {
            return answer == target;
        }
    }
}

namespace Interview.HashTable
{
    public class FindAllAnagramsInString
    {
        public static IList<int> Execute(string s, string p)
        {
            Func<char, int> getIndex =
                (char c) => c - 'a';

            var result = new List<int>();
            int[] p_chars = new int[26];
            foreach (char c in p)
                p_chars[getIndex(c)]++;

            int left = 0;
            int right = 0;
            int count = p.Length;

            while (right < s.Length)
            {
                var right_letter = s[right];
                right++;

                var right_letter_index = getIndex(right_letter);
                p_chars[right_letter_index]--;
                if (p_chars[right_letter_index] >= 0)
                    count--;

                if (count == 0)
                    result.Add(left);

                if (right - left == p.Length)
                {
                    var left_letter = s[left];
                    left++;
                    var left_letter_index = getIndex(left_letter);
                    p_chars[left_letter_index]++;
                    if (p_chars[left_letter_index] > 0)
                        count++;
                }
            }

            return result;
        }

        public static IEnumerable<(string s, string p, IList<int> answer)> GetTests()
        {
            yield return ("cbaebabacd", "abc", new int[] { 0, 6 });
            yield return ("abab", "ab", new int[] { 0, 1, 2 });
        }

        public static bool CheckResult(IList<int> result, IList<int> answer)
        {
            if (result.Count != answer.Count)
                return false;
            return result.SequenceEqual(answer);
        }
    }
}

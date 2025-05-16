namespace TopInterview150.Array_String
{
    public static class H_Index
    {
        /// <summary>
        /// Given an array of integers citations where citations[i] is the number of citations a researcher received for their ith paper, 
        /// return the researcher's h-index. According to the definition of h-index on Wikipedia: 
        /// The h-index is defined as the maximum value of h such that the given researcher has published 
        /// at least h papers that have each been cited at least h times.
        /// </summary>
        public static int Execute(int[] citations)
        {
            var n = citations.Length;
            var count = new int[n + 1];
            foreach (var citation in citations)
                count[Math.Min(citation, n)]++;

            var answer = 0;
            for(int i = n; i >= 0; i--)
            {
                answer += count[i];
                if (answer >= i)
                    return i;
            }
            return 0;
        }

        public static IEnumerable<(int[] citations, int answer)> GetTests()
        {
            yield return (new int[] { 3, 0, 6, 1, 5 }, 3);
            yield return (new int[] { 1, 3, 1 }, 1);
        }

        public static bool CheckResult(int result, int answer)
        {
            return result == answer;
        }
    }
}

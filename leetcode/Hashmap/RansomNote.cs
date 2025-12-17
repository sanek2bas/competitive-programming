namespace TopInterview150.Hashmap
{
    public static class RansomNote
    {
        

        public static IEnumerable<(string ransomNote, string magazine, bool answer)> GetTests()
        {
            yield return ();
            yield return ();
            yield return ();
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return answer == result;
        }
    }
}

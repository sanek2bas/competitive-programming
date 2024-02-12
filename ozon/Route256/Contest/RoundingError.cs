namespace Route256.Contest
{
    public static class RoundingError
    {
        public static string Execute(int precent, IList<int> prices)
        {
            var sum = 0;
            foreach (var price in prices) 
            {
                sum += ((price % 100) * precent) % 100;
            }
            var kop = sum % 100;
            return $"{sum / 100}.{kop/10}{kop%10}";
        }

        public static IEnumerable<(int precent, IList<int> prices, string answer)> GetTests()
        {
            yield return (1, new int[] { 1, 2, 3, 4, 5 }, "0.15");
            yield return (5, new int[] { 40 }, "0.00");
            yield return (99, new int[] { 1, 50 }, "1.49");
            yield return (76, new int[] { 461539143 }, "0.68");
        }

        public static bool CheckResult(string result, string answer)
        {
            return result == answer;
        }
    }
}

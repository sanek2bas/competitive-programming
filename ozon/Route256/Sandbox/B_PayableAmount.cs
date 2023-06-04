namespace Route256.Sandbox
{
    public static class B_PayableAmount
    {
        public static void Main()
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var pricesCount = Console.ReadLine();
                var prices = Console.ReadLine()
                    .Split()
                    .Select(x => Convert.ToInt64(x))
                    .ToArray();

                var priceGroups = prices.GroupBy(p => p);
                long summ = 0;
                foreach (var priceGroup in priceGroups)
                {
                    var count = priceGroup.Count();
                    summ += priceGroup.Key * (count - count / 3);
                }

                Console.WriteLine(summ);
            }
        }
    }
}

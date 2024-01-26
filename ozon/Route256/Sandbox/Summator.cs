namespace Route256.Sandbox
{
    public static class Summator
    {
        public static void Main()
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var twoNumbers = Console.ReadLine()
                    .Split()
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();
                Console.WriteLine(twoNumbers[0] + twoNumbers[1]);
            }
        }
    }
}
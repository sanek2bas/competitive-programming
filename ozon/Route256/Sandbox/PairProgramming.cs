namespace Route256.Sandbox
{
    public static class PairProgramming
    {
        public static void Main()
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var programersCount = Convert.ToInt32(Console.ReadLine());
                var programers = Console.ReadLine()
                    .Split()
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();

                var usedProgramers = new bool[programersCount];
                int index = 0;
                while (index < programersCount - 1)
                {
                    if (!usedProgramers[index])
                    {
                        var minDiff = int.MaxValue;
                        var wantedPairIndex = -1;
                        for (int j = index + 1; j < programersCount; j++)
                        {
                            if (usedProgramers[j])
                                continue;
                            var curDiff = Math.Abs(programers[index] - programers[j]);
                            if (minDiff > curDiff)
                            {
                                minDiff = curDiff;
                                wantedPairIndex = j;
                            }
                        }

                        Console.WriteLine($"{index + 1} {wantedPairIndex + 1}");
                        usedProgramers[wantedPairIndex] = true;
                        usedProgramers[index] = true;
                    }

                    index++;
                }

                Console.WriteLine();
            }
        }
    }
}

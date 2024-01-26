namespace Route256.Sandbox
{
    public static class ElectronicWorlsheet
    {
        public static void Main()
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                string? _ = Console.ReadLine();
                var tableSize = Console.ReadLine()
                    .Split()
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();
                int rowsCount = tableSize[0];
                int columnCount = tableSize[1];

                var rows = new List<int[]>();
                for (int r = 0; r < rowsCount; r++)
                {
                    rows.Add(
                        Console.ReadLine()
                        .Split()
                        .Select(x => Convert.ToInt32(x))
                        .ToArray());
                }

                var sortCount = Convert.ToInt32(Console.ReadLine());
                var sorts = Console.ReadLine()
                    .Split()
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();

                for (int s = 0; s < sortCount; s++)
                {
                    rows = rows
                        .OrderBy(x => x[sorts[s] - 1])
                        .ToList();
                }

                foreach (var row in rows)
                {
                    foreach (int number in row)
                        Console.Write($"{number} ");
                }

                Console.WriteLine();
            }
        }
    }
}

namespace Route256.Contest
{
    public static class D_CompResult
    {
        public static void Main()
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var athletesCount = Convert.ToInt32(Console.ReadLine());
                var atheletes = new Athlete[athletesCount];
                var results = Console.ReadLine()
                    .Split()
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();
                for (int j = 0; j < athletesCount; j++)
                {
                    atheletes[j] = new Athlete(j)
                    {
                        Result = results[j]
                    };
                }

                atheletes = atheletes.OrderBy(x => x.Result).ToArray();
                int nextPlace = 1;
                int minPlace = 1;
                int minResult = atheletes[0].Result;
                foreach (var athelete in atheletes)
                {
                    if (athelete.Result == minResult)
                    {
                        athelete.Place = minPlace;
                    }
                    else if (athelete.Result == minResult + 1)
                    {
                        athelete.Place = minPlace;
                        minResult = minResult + 1;
                    }
                    else
                    {
                        athelete.Place = nextPlace;
                        minResult = athelete.Result;
                        minPlace = nextPlace;
                    }
                    nextPlace++;
                }

                atheletes = atheletes.OrderBy(x => x.Id).ToArray();
                foreach (var athelete in atheletes)
                {
                    Console.Write($"{athelete.Place} ");
                }
                Console.WriteLine();
            }
        }

        private class Athlete
        {
            public int Id { get; }
            public int Result { get; set; }
            public int Place { get; set; }

            public Athlete(int id)
            {
                Id = id;
            }
        }
    }
}

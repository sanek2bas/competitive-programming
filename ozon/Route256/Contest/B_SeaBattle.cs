namespace Route256.Contest
{
    public static class B_SeaBattle
    {
        public static void Main()
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < testCount; i++)
            {
                var field = new int[4];
                foreach (var shape in Console.ReadLine().
                                      Split().
                                      Select(x => Convert.ToInt32(x)))
                {
                    field[shape - 1]++;
                }

                string answer = "YES";
                if (field[0] != 4 ||
                    field[1] != 3 ||
                    field[2] != 2 ||
                    field[3] != 1)
                    answer = "NO";
                Console.WriteLine(answer);
            }
        }
    }
}

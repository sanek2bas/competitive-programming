namespace Route256.Sandbox
{
    public static class BattleForAirConditioning
    {
        /// <summary>
        /// В офисе стоит кондиционер, на котором можно установить температуру от 15 до 30 градусов.
        /// В офис по очереди приходят n сотрудников. i-й из них желает температуру не больше или не меньше ai;​
        /// После прихода каждого сотрудника определите, можно ли выставить температуру, которая удовлетворит всех в офисе.
        /// </summary>
        public static int[] Execute(string[] temperatureLimits)
        {
            int min = 15;
            int max = 30;
            var answers = new List<int>();
            foreach (var temperatureLimit in temperatureLimits) 
            {
                var temperatureLimitArr = temperatureLimit.Split(' ');
                var temperature = Convert.ToInt32(temperatureLimitArr[1]);
                if (temperatureLimitArr[0] == ">=")
                {
                    if (temperature > min)
                        min = temperature;
                }
                else
                {
                    if (temperature < max)
                        max = temperature;
                }
                if (min <= max)
                    answers.Add(min);
                else
                    answers.Add(-1);
            }
            return answers.ToArray();
        }

        public static IEnumerable<(string[] temperatureLimits, int[] answer)> GetTests()
        {
            yield return (
                new string[] { ">= 30" },
                new int[] { 30 });
            yield return (
                new string[] { ">= 18", "<= 23", ">= 20", "<= 27", "<= 21", ">= 28" },
                new int[] { 18, 18, 20, 20, 20, -1 });
            yield return (
                new string[] { "<= 25", ">= 20", ">= 25" },
                new int[] { 15, 20, 25 });
            yield return (
                new string[] { "<= 15", ">= 30", "<= 24" },
                new int[] { 15, -1, -1 });
        }

        public static bool CheckResult(int[] result, int[] answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}

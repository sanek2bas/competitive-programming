namespace Route256.Sandbox
{
    public static class TimeSplit
    {
        public static void Main()
        {
            var maxValueSeconds = new TimeSpan(23, 59, 59);
            var minValueSeconds = new TimeSpan(0, 0, 0);

            int employeesCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < employeesCount; i++)
            {
                var intervalsCount = Convert.ToInt32(Console.ReadLine());
                var intervalsStr = new List<string>();
                for (int j = 0; j < intervalsCount; j++)
                    intervalsStr.Add(Console.ReadLine());

                var intervals = new List<Interval>();
                string answer = "YES";
                var ticks = new bool[24 * 60 * 60];
                foreach (var intervalStr in intervalsStr)
                {
                    var interval = convertToInterval(intervalStr);
                    bool check = true;
                    if (interval == null)
                    {
                        check = false;
                    }
                    else
                    {
                        for (int t = (int)interval.Start.TotalSeconds; t <= (int)interval.End.TotalSeconds; t++)
                        {
                            if (ticks[t])
                            {
                                check = false;
                                break;
                            }
                            else
                            {
                                ticks[t] = true;
                            }
                        }
                    }

                    if (!check)
                    {
                        answer = "NO";
                        break;
                    }

                    intervals.Add(interval);
                }
                Console.WriteLine(answer);
            }

        }

        private static Interval convertToInterval(string intervalStr)
        {
            var hours = convertToNumber(intervalStr[0], intervalStr[1]);
            if (hours < 0 || hours >= 24)
                return null;
            var minutes = convertToNumber(intervalStr[3], intervalStr[4]);
            if (minutes < 0 || minutes >= 60)
                return null;
            var seconds = convertToNumber(intervalStr[6], intervalStr[7]);
            if (seconds < 0 || seconds >= 60)
                return null;
            var start = new TimeSpan(hours, minutes, seconds);

            hours = convertToNumber(intervalStr[9], intervalStr[10]);
            if (hours < 0 || hours >= 24)
                return null;
            minutes = convertToNumber(intervalStr[12], intervalStr[13]);
            if (minutes < 0 || minutes >= 60)
                return null;
            seconds = convertToNumber(intervalStr[15], intervalStr[16]);
            if (seconds < 0 || seconds >= 60)
                return null;
            var end = new TimeSpan(hours, minutes, seconds);

            if (start > end)
                return null;

            return new Interval()
            {
                Start = start,
                End = end
            };
        }

        private static int convertToNumber(char ten, char one)
        {
            return convertToInt(ten) * 10 + convertToInt(one);
        }

        private static int convertToInt(char c)
        {
            return (int)Char.GetNumericValue(c);
        }

        private class Interval
        {
            public TimeSpan Start { get; set; }
            public TimeSpan End { get; set; }
        }
    }
}

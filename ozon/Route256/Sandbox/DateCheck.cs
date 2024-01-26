namespace Route256.Sandbox
{
    public static class DateCheck
    {
        /// <summary>
        /// Задана дата в формате "день месяц год" в виде трёх целых чисел. Гарантируется, что:
        /// ∙ день — это целое число от 1 до 31;
        /// месяц — это целое число от 1 до 12;
        /// год — это целое число от 1950 до 2300.
        /// Проверьте, что заданные три числа соответствуют корректной дате(в современном григорианском календаре).
        /// Напоминаем, что в соответствии с современным календарём год считает високосным, если для этого года верно хотя бы одно из утверждений:
        /// · делится на 4, но при этом не делится на 100;
        /// · делится на 400.
        /// Например, годы 2012 и 2000 являются високосными, но годы 1999, 2022 и 2100 - нет.
        /// </summary>
        public static bool Execute(int d, int m, int y)
        {
            if (m == 2)
            {
                if (d < 29)
                    return true;
                else if (d > 29)
                    return false;
                return (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
            }
            else if (m is 4 or 6 or 9 or 9 or 11)
            {
                return d < 31;
            }
            return true;
        }

        public static IEnumerable<(int d, int m, int y, bool answer)> GetTests()
        {
            yield return (10, 9, 2022, true);
            yield return (21, 9, 2022, true);
            yield return (29, 2, 2022, false);
            yield return (31, 2, 2022, false);
            yield return (29, 2, 2000, true);
            yield return (29, 2, 2100, false);
            yield return (31, 11, 1999, false);
            yield return (31, 12, 1999, true);
            yield return (29, 2, 2024, true);
            yield return (29, 2, 2023, false);
        }

        public static bool CheckResult(bool result, bool answer)
        {
            return result == answer;
        }
    }
}

namespace Route256.Contest
{
    public static class SeaBattle
    {
        /// <summary>
        /// Вы участвуете в разработке подсистемы проверки поля для игры Морской бой. 
        /// Вам требуется написать проверку корректности количества кораблей на поле, учитывая их размеры. Напомним, что на поле должны быть:
        /// ∙ четыре однопалубных корабля,
        /// ∙ три двухпалубных корабля,
        /// ∙ два трёхпалубных корабля,
        /// ∙ один четырёхпалубный корабль.
        /// Вам заданы 10 целых чисел от 1 до 4.
        /// Проверьте, что заданные размеры соответствуют требованиям выше.
        /// </summary>
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

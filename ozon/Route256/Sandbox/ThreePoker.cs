namespace Route256.Sandbox
{
    public static class ThreePoker
    {
        /// <summary>
        /// Колода состоит из 52 карт. Каждая карта обозначается одним из тринадцати значений 
        /// (2, 3, 4, 5, 6, 7, 8, 9, Ten, Jack, Queen, King, Ace) и одной из четырех мастей
        /// (Spades, Clubs, Diaomnds, Hearts).
        /// Выдуманная игра 3-Покер происходит следующим образом.
        /// 1. Изначально все n игроков получают по две карты из колоды.
        /// 2. После этого на стол выкладывается одна карта из той же колоды.
        /// 3. Выигрывают те игроки, у которых собралась самая старшая комбинация.
        /// Для определения самой старшей комбинации, которая собралась у i-ого игрока, используются следующие правила:
        /// - если две карты у игрока в руке и карта на столе имеют одинаковое значение, игрок собрал комбинацию 'Сет со значением x'
        /// - если из двух карт у игрока в руке и карты на столе можно выбрать две карты с одинаковым значением x, игрок собрал комбинацию 'Пара со значением x'
        /// - иначе, берется карта с самым старшим значением из двух карт у игрока в руке и карты на столе, тогда игрок собрал комбинацию 'Старшая карта со значением x'.
        /// Любой сет старше пары, а любая пара старше комбинации старшая карта. 
        /// Из одинаковых комбинаций старше та, у которой старше значение. 
        /// Если одинаковая самая старшая комбинация есть у нескольких игроков, все они объявляются выигрывшими.
        /// </summary>
        public static IList<string> Execute(IList<(string, string)> cards)
        {
            var values = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
            var colors = new char[] { 'S', 'C', 'D', 'H' };
            var dic  = new Dictionary<char, HashSet<char>>();
            foreach (var value in values)
                dic.Add(value, colors.ToHashSet());

            var myCard1 = cards[0].Item1;
            var myCard2 = cards[0].Item2;

            for (int i = 1; i < cards.Count; i++)
            {
                var value1 = cards[i].Item1[0];
                var color1 = cards[i].Item1[1];
                var value2 = cards[i].Item2[0];
                var color2 = cards[i].Item2[1];
                dic[value1].Remove(color1);
                dic[value2].Remove(color2);
            }

            if (myCard1[0] == myCard2[0])
            {

            }

            return new List<string>();
        }

        public static IEnumerable<(IList<(string, string)> cards, IList<string> answer)> GetTests()
        {
            yield return (
                new List<(string, string)>
                {
                    ("TS", "TC"),
                    ("AD", "AH")
                },
                new List<string> { "TD", "TH" });
            yield return (
                new List<(string, string)>
                {
                    ("2H", "3H"),
                    ("9S", "9C"),
                    ("4D", "QS")
                },
                new List<string>());
            yield return (
                new List<(string, string)>
                {
                    ("4C", "7H"),
                    ("4H", "4D"),
                    ("6S", "6H")
                },
                new List<string> { "7S", "7C", "7D" });
            yield return (
                new List<(string, string)>
                {                  
                    ("AS", "AC"),
                    ("AD", "AH"),
                    ("KS", "JH"),
                    ("9D", "9C"),
                    ("5H", "5D"),
                    ("3C", "3S"),
                    ("TC", "TH")
                },
                new List<string>());
            yield return (
                new List<(string, string)>
                {
                    ("2S", "3H"),
                    ("2C", "2D"),
                    ("3C", "3D")
                },
                new List<string> { "2S", "2C", "2D", "2H", "4S", "4C", "4D", "4H", "6S", "6C", 
                                   "6D", "6H", "7S", "7C", "7D", "7H", "8S", "8C", "8D", "8H", 
                                   "JS", "JC", "JD", "QS", "QC", "QD", "QH", "KC", "KD", "KH" });
        }

        public static bool CheckResult(int[] result, int[] answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}

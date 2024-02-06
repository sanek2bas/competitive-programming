using System.Text;

namespace Route256.Sandbox
{
    public static class Terminal
    {
        /// <summary
        /// Реализуйте элемент функциональности простейшего терминала.
        /// Изначально терминал содержит одну пустую строку, в начале которой находится курсор.
        /// Ваша программа должна уметь обрабатывать последовательность символов (строку ввода). Обработка символа зависит от его значения:
        /// - Строчная буква латинского алфавита или цифра обозначает, что соответствующий символ вставляется в положение курсора.
        ///   Курсор сдвигается на позицию после вставленного символа.
        /// - Буквы L и R обозначают нажатия стрелок влево и вправо.
        ///   Они перемещают курсор на одну позицию влево или вправо. 
        ///   Если в соответствующем направлении нет символа, то операция игнорируется. 
        ///   Заметьте, что курсор в любом случае остаётся в той же строке.
        /// - Буквы U и D обозначают нажатия стрелок вверх и вниз.
        ///   Они перемещают курсор на одну позицию вверх или вниз. Если в соответствующем направлении нет строки, то операция
        ///   игнорируется. Если строка есть, но в ней нужная позиция не существует, то курсор встаёт в конец строки.
        /// - Буквы B и E обозначают нажатия клавиш Home и End. Они перемещают курсор в начало или в конец текущей строки.
        /// - Буква N обозначает нажатие клавиши Enter — происходит вставка новой строки. 
        ///   Если курсор находился не в конце текущей строки, то она разрывается, и часть после курсора переносится в новую строку. 
        ///   Курсор после этой операции стоит в начале новой строки.
        /// </summary>
        public static string[] Execute(string str)
        {
            var result = new List<StringBuilder>();
            result.Add(new StringBuilder(""));
            int row = 0;
            int col = 0;
            foreach(var ch in str)
            {
                switch(ch) 
                {
                    case 'L':
                        if (col > 0)
                            col--;
                        break;
                    case 'R':
                        if (col < result[row].Length)
                            col++;
                        break;
                    case 'U':
                        if (row > 0)
                        {
                            row--;
                            if (col > result[row].Length)
                                col = result[row].Length;
                        }
                        break;
                    case 'D':
                        if (row < result.Count - 1)
                        {
                            row++;
                            if (col > result[row].Length)
                                col = result[row].Length;
                        }   
                        break;
                    case 'B':
                        col = 0;
                        break;
                    case 'E':
                        col = result[row].Length;
                        break;
                    case 'N':
                        var substr = string.Empty;
                        if(col < result[row].Length)
                        {
                            substr = result[row].ToString(col, result[row].Length - col);
                            result[row].Remove(col, result[row].Length - col);
                        }
                        result.Insert(++row, new StringBuilder(substr));
                        col = 0;
                        break;
                    default:
                        if (col >= result[row].Length)
                            result[row].Append(ch);
                        else
                            result[row].Insert(col, ch);
                        col++;
                        break;
                }
            }
            return result.Select(x => x.ToString())
                         .ToArray();
        }

        public static IEnumerable<(string str, string[] answer)> GetTests()
        {
            yield return (
                "otLLLrRuEe256LLLN",
                new string[] 
                {
                    "route",
                    "256"
                });
            yield return (
                "LRLUUDE",
                new string[]
                {
                    ""
                });
            yield return (
                "itisatest",
                new string[]
                {
                    "itisatest"
                });
            yield return (
                "abNcdLLLeUfNxNx",
                new string[]
                {
                    "af",
                    "x",
                    "xb",
                    "ecd"
                });
            yield return (
                "UERL9NLioeLRBDweE8UD05L3Dzdx1",
                new string[]
                {
                    "9",
                    "w03zdx15eioe8"
                });
            
        }

        public static bool CheckResult(string[] result, string[] answer)
        {
            return result.SequenceEqual(answer);
        }
    }
}

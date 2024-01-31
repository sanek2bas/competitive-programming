using System.Text;

namespace Route256.Contest
{
    public static class MotorcarPlate
    {
        /// <summary>
        /// В Берляндии автомобильные номера состоят из цифр и прописных букв латинского алфавита. Они бывают двух видов:
        /// - либо автомобильный номер имеет вид буква − цифра − цифра − буква − буква (R48FA, O00OO, A99OK);
        /// - либо автомобильный номер имеет вид буква − цифра − буква − буква (T7RR, A9PQ, O0OO).
        /// Таким образом, каждый автомобильный номер является строкой либо первого, либо второго вида.
        /// Вам задана строка из цифр и прописных букв латинского алфавита. Можно ли разделить её пробелами на последовательность 
        /// корректных автомобильных номеров? Иными словами, проверьте, что заданная строка может быть образована как последовательность 
        /// корректных автомобильных номеров, которые записаны подряд без пробелов. В случае положительного ответа выведите любое такое разбиение.
        /// </summary>
        public static string Execute(string str)
        {
            var answer = new StringBuilder();
            var left = 0;
            var right = 3;
            while(left < str.Length)
            {
                if (right >= str.Length)
                    return "-";
                var plate = str.Substring(left, right - left + 1);

                if(plate.Length == 4)
                {
                    if(checkPlate1(plate))
                    {
                        answer.Append($"{plate} ");
                        left = right + 1;
                        right = left + 3;
                    }
                    else
                    {
                        right++;
                    }
                }
                else if (checkPlate2(plate))
                {
                    answer.Append($"{plate} ");
                    left = right + 1;
                    right = left + 3;
                }
                else
                {
                    return "-";
                }
            }
            return answer.Remove(answer.Length - 1, 1).ToString();
        }

        private static bool checkPlate1(string plate)
        {
            if (plate.Length != 4)
                return false;
            if (!char.IsLetter(plate[0]))
                return false;
            if (!char.IsNumber(plate[1]))
                return false;
            if (!char.IsLetter(plate[2]))
                return false;
            if (!char.IsLetter(plate[3]))
                return false;
            return true;
        }

        private static bool checkPlate2(string plate)
        {
            if (plate.Length != 5)
                return false;
            if (!char.IsLetter(plate[0]))
                return false;
            if (!char.IsNumber(plate[1]))
                return false;
            if (!char.IsNumber(plate[2]))
                return false;
            if (!char.IsLetter(plate[3]))
                return false;
            if (!char.IsLetter(plate[4]))
                return false;
            return true;
        }

        public static IEnumerable<(string str, string answer)> GetTests()
        {
            yield return ("R48FAO00OOO0OOA99OKA99OK", "R48FA O00OO O0OO A99OK A99OK");
            yield return ("R48FAO00OOO0OOA99OKA99O", "-");
            yield return ("A9PQ", "A9PQ");
            yield return ("A9PQA", "-");
            yield return ("A99AAA99AAA99AAA99AA", "A99AA A99AA A99AA A99AA");
            yield return ("AP9QA", "-");
        }

        public static bool CheckResult(string result, string answer)
        {
            return result == answer;
        }
    }
}

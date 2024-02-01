using System.Text;

namespace Route256.Contest
{
    public static class PrintDoc
    {
        /// <summary>
        /// Необходимо напечатать документ из k страниц.Его страницы пронумерованы от 1 до k.
        /// Некоторые его страницы были уже предварительно напечатаны. Известно, что на принтер было отослано одно задание,
        /// которое содержало список страниц для печати. Этот список содержит хотя бы одну страницу, 
        /// и хотя бы одна страница от 1 до k не попадает в этот список.
        /// Список страниц состоит из перечисленных через единичную запятую элементов списка, где каждый элемент — это:
        /// - либо конкретный номер одной страницы (целое число от 1 до k),
        /// - либо диапазон страниц, записанный в формате «l-r», где l — начало диапазона печати, 
        /// а r — конец диапазона печати(и l и r целые числа, удовлетворяющие неравенству 1≤l≤r≤k).
        /// Страница может многократно присутствовать в списке на печать, но будет напечатана лишь единожды.
        /// Иными словами, список страниц имеет формат, аналогичный тому, что используется в «Microsoft Word» или других подобных программах.
        /// Выведите кратчайший список страниц в аналогичном формате, который надо дополнительно послать на печать, чтобы в итоге напечатать все страницы от 
        /// 1 до k, не напечатанные ранее. Иными словами, найдите такую наиболее короткую строку, 
        /// которая является корректным списком страниц и содержит те и только те страницы, которые еще не были напечатаны.
        /// Если ответов несколько, то выведите любой из них.

        /// </summary>
        public static string Execute(int pagesCount, string printedPages)
        {
            var splitedPrintedPages = printedPages.Split(',');

            var printedPagesSet = new SortedSet<int>();
            foreach (var page in splitedPrintedPages)
            {
                var pages = page.Split('-');
                int firstPage = Convert.ToInt32(pages[0]);
                int lastPage = pages.Length == 1
                    ? firstPage
                    : Convert.ToInt32(pages[1]);
                for (int j = firstPage; j <= lastPage; j++)
                {
                    if (!printedPagesSet.Contains(j))
                        printedPagesSet.Add(j);
                }
            }

            var answer = new StringBuilder();
            int startRange = 0;
            int endRange = 0;
            for (int j = 1; j <= pagesCount; j++)
            {
                if (printedPagesSet.Contains(j))
                {
                    if (startRange > 0)
                    {
                        if (startRange == endRange)
                            answer.Append(startRange);
                        else
                            answer.Append($"{startRange}-{endRange}");
                        answer.Append(',');
                        startRange = 0;
                        endRange = 0;
                    }
                }
                else if (startRange == 0)
                {
                    startRange = j;
                    endRange = j;
                }
                else
                {
                    endRange++;
                }
            }
            if (startRange > 0)
            {
                if (startRange == endRange)
                    answer.Append(startRange);
                else
                    answer.Append($"{startRange}-{endRange}");
            }
            else
            {
                answer = answer.Remove(answer.Length - 1, 1);
            }
            return answer.ToString();
        }

        public static IEnumerable<(int pagesCount, string printedPages, string answer)> GetTests()
        {
            yield return (8, "7", "1-6,8");
            yield return (8, "1,7,1", "2-6,8");
            yield return (8, "1-5,1,7-7", "6,8");
            yield return (10, "1-5", "6-10");
            yield return (10, "1,2,3,4,5,6,8,9,10", "7");
            yield return (3, "1-2", "3");
            yield return (100, "1-2,3-7,10-20,100", "8-9,21-99");
        }

        public static bool CheckResult(string result, string answer)
        {
            return result == answer;
        }
    }
}

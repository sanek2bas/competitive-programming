using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route256.Contest
{
    public static class F_PrintDoc
    {
        public static void Main()
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var pagesCount = Convert.ToInt32(Console.ReadLine());
                var printedPages = Console.ReadLine().Split(',');

                var printedPagesSet = new SortedSet<int>();
                foreach (var page in printedPages)
                {
                    var pages = page.Split('-');
                    int firstPage = Convert.ToInt32(pages[0]);
                    int lastPage = pages.Length == 1 
                        ? firstPage 
                        : Convert.ToInt32(pages[1]);
                    for(int j = firstPage; j <= lastPage; j++)
                    {
                        if (printedPagesSet.Contains(j))
                            continue;
                        printedPagesSet.Add(j);
                    }
                }

                var answer = new StringBuilder();
                int startRange = 0;
                int endRange = 0;
                for(int j = 1; j <= pagesCount; j++)
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
                    startRange = 0;
                    endRange = 0;
                }
                else
                {
                    answer = answer.Remove(answer.Length-1, 1);
                }
                Console.WriteLine(answer);
            }
        }
    }
}

using System.Text;
using System.Collections;

namespace Route256.Sandbox
{
    public static class CommentTree
    {
        /// <summary>
        /// Вам задан набор комментариев. Каждый комментарий описывается тремя параметрами:
        /// ∙ своим идентификатором(уникальное целое число от 1 до 10^9)
        /// ∙ идентификатором предка(или -1, если предка нет)
        /// ∙ своим текстом(непустая строка из символов с кодами от 32 до 126, включительно)
        /// Выведите заданные комментарии в древесном виде, отформатировав их в точности так, как изображено в примерах.
        /// </summary>
        public static string Execute(IList<(int id, int parentId, string text)> comments)
        {
            var dic = new Dictionary<int, string>();
            var sortedIds = new Dictionary<int, List<int>>();
            foreach (var comment in comments)
            {
                dic.Add(comment.id, comment.text);
                if (!sortedIds.ContainsKey(comment.parentId))
                    sortedIds.Add(comment.parentId, new List<int>());
                sortedIds[comment.parentId].Add(comment.id);
            }

            var rootIdList = sortedIds[-1].Order().ToList();
            var result = new StringBuilder();
            for (int i = 0; i < rootIdList.Count; i++)
            {
                var id = rootIdList[i];                
                result.Append(dic[id]);
                addLines(id, "|", sortedIds, dic, result);
                if (i < rootIdList.Count - 1)
                {
                    result.Append("\r\n");
                    result.Append("\r\n");
                }
            }
            return result.ToString();
        }

        private static void addLines(int parentId, string startLine, Dictionary<int, List<int>> sortedIds, Dictionary<int, string> dic, StringBuilder result)
        {
            if (!sortedIds.ContainsKey(parentId))
                return;
            var idList = sortedIds[parentId].Order().ToList();
            for (int i = 0; i < idList.Count; i++)
            {
                var id = idList[i];
                result.Append("\r\n");
                result.Append($"{startLine}\r\n");
                result.Append($"{startLine}--");
                result.Append(dic[id]);
                if (i == idList.Count - 1)
                    startLine = startLine.Remove(startLine.Length - 1) + " ";
                addLines(id, startLine + "  |", sortedIds, dic, result);
            }
        }

        public static IEnumerable<(IList<(int id, int parentId, string text)> comments, string answer)> GetTests()
        {
            yield return (
                new List<(int, int, string)>()
                {
                    (75, 22, "I'm fine. Thank you."),
                    (84, 82, "    Ciao!"),
                    (26, 22, "So-so"),
                    (45, 26, "What's wrong?"),
                    (22, -1, "How are you?"),
                    (72, 45, "Maybe I got sick"),
                    (81, 72, "I wish you a speedy recovery!"),
                    (97, 26, "  Stick it!"),
                    (2, 97, "Thanks"),
                    (47, 72, "I also got sick recently."),
                    (25, -1, "Hi!"),
                    (82, -1, "Bye"),
                    (17, 82, "Good day!"),
                    (29, 72, "Visit the doctor")
                },
                "How are you?\r\n" +
                "|\r\n" +
                "|--So-so\r\n" +
                "|  |\r\n" +
                "|  |--What's wrong?\r\n" +
                "|  |  |\r\n" +
                "|  |  |--Maybe I got sick\r\n" +
                "|  |     |\r\n" +
                "|  |     |--Visit the doctor\r\n" +
                "|  |     |\r\n" +
                "|  |     |--I also got sick recently.\r\n" +
                "|  |     |\r\n" +
                "|  |     |--I wish you a speedy recovery!\r\n" +
                "|  |\r\n" +
                "|  |--  Stick it!\r\n" +
                "|     |\r\n" +
                "|     |--Thanks\r\n" +
                "|\r\n" +
                "|--I'm fine. Thank you.\r\n" +
                "\r\n" +
                "Hi!\r\n" +
                "\r\n" +
                "Bye\r\n" +
                "|\r\n" +
                "|--Good day!\r\n" +
                "|\r\n" +
                "|--    Ciao!");
            yield return (
                new List<(int, int, string)>()    
                {
                    (5, 4, "e"),
                    (6, 5, "f"),
                    (7, 6, "g"),
                    (1, -1, "a"),
                    (2, 1, "b"),
                    (3, 2, "c"),
                    (4, 3, "d"),
                    (8, 7, "h")
                },
                "a\r\n" +
                "|\r\n" +
                "|--b\r\n" +
                "   |\r\n" +
                "   |--c\r\n" +
                "      |\r\n" +
                "      |--d\r\n" +
                "         |\r\n" +
                "         |--e\r\n" +
                "            |\r\n" +
                "            |--f\r\n" +
                "               |\r\n" +
                "               |--g\r\n" +
                "                  |\r\n" +
                "                  |--h");
            yield return (
               new List<(int, int, string)>()
               {
                   (10, -1, "x"),
                   (20, 10, "x"),
                   (40, -1, "x"),
                   (50, -1, "x"),
                   (11, 20, "x"),
                   (30, 10, "x")
               },
               "x\r\n" +
               "|\r\n" +
               "|--x\r\n" +
               "|  |\r\n" +
               "|  |--x\r\n" +
               "|\r\n" +
               "|--x\r\n" +
               "\r\n" +
               "x\r\n" +
               "\r\n" +
               "x");
            yield return (
               new List<(int, int, string)>()
               {
                   (1_000_000_000, -1, "root")
               },
               "root");
        }

        public static bool CheckResult(string result, string answer)
        {
            return result == answer;
        }
    }
}

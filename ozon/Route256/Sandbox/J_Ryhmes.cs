using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace Route256.Sandbox
{
    public static class J_Ryhmes
    {
        public static void Main()
        {
            var dicCapacity = Convert.ToInt32(Console.ReadLine());
            var wordsList = new SortedList<string, string>();
            
            for (int i = 0; i < dicCapacity; i++)
            {
                var word = Console.ReadLine();
                wordsList.Add(reverseString(word), word);
            }

            var queriesCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < queriesCount; i++)
            {
                var query = Console.ReadLine();
                var answer = findWord(reverseString(query), wordsList);
                Console.WriteLine(wordsList[answer]);
            }
        }

        private static string findWord(string query, SortedList<string, string> sortedList)
        {
            (string left, string right) neighbourhoods;
            if (sortedList.ContainsKey(query))
            {
                neighbourhoods = getNeighbourhoods(query, sortedList);
            }
            else
            {
                sortedList.Add(query, string.Empty);
                neighbourhoods = getNeighbourhoods(query, sortedList);
                sortedList.Remove(query);
            }
            

            var maxRyhme = 0;
            var result = string.Empty;

            if (!string.IsNullOrEmpty(neighbourhoods.left))
            {
                var ryhme = findMaxRyhme(query, neighbourhoods.left);
                if (ryhme > maxRyhme)
                {
                    maxRyhme = ryhme;
                    result = neighbourhoods.left;
                }

            }

            if (!string.IsNullOrEmpty(neighbourhoods.right))
            {
                var ryhme = findMaxRyhme(query, neighbourhoods.right);
                if (ryhme > maxRyhme)
                {
                    maxRyhme = ryhme;
                    result = neighbourhoods.right;
                }
            }

            if (string.IsNullOrEmpty(result))
            {
                result = sortedList.Where(i => i.Key != query).First().Key;
            }

            return result;
        }

        private static (string left, string right) getNeighbourhoods(string query, SortedList<string, string> sortedList)
        {
            var queryIdx = sortedList.IndexOfKey(query);
            var leftNeighbourhood = queryIdx - 1 >= 0
                ? sortedList.ElementAt(queryIdx - 1).Key
                : string.Empty;
            var rightNeighbourhood = queryIdx + 1 < sortedList.Count 
                ? sortedList.ElementAt(queryIdx + 1).Key
                : string.Empty;
            return new(leftNeighbourhood, rightNeighbourhood);
        }

        private static int findMaxRyhme(string s1, string s2)
        {
            var count = 0;

            if(s1 != s2)
            {
                for (int i = 0; i < Math.Min(s1.Length, s2.Length); i++)
                {
                    if (s1[i] != s2[i])
                        break;
                    count++;
                }                
            }
            
            return count;
        }

        //private static int findMaxRyhme(string query, string word)
        //{
        //    if (query == word)
        //        return 0;

        //    var idx = 0;
        //    int ryhme = 0;

        //    while (idx < query.Length && idx < word.Length)
        //    {
        //        if (query[idx] != word[idx])
        //            break;

        //        ryhme++;
        //        idx++;
        //    }

        //    return ryhme;
        //}

        private static string reverseString(string original)
        {
            var charArr = original.ToCharArray();
            Array.Reverse(charArr);
            return new string(charArr);
        }
    }
}

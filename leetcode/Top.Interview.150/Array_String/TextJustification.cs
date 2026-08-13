using System.Text;

namespace Top.Interview._150.Array_String;

public class TextJustification
{
    /// <summary>
    /// # 68
    /// https://leetcode.com/problems/text-justification/description/
    /// Given an array of strings words and a width maxWidth, format the text 
    /// such that each line has exactly maxWidth characters and is fully 
    /// (left and right) justified.
    /// You should pack your words in a greedy approach; that is, pack as many 
    /// words as you can in each line. Pad extra spaces ' ' when necessary 
    /// so that each line has exactly maxWidth characters.
    /// Extra spaces between words should be distributed as evenly as possible.
    /// If the number of spaces on a line does not divide evenly between words, 
    /// the empty slots on the left will be assigned more spaces than the slots 
    /// on the right.
    /// For the last line of text, it should be left-justified, and no extra 
    /// space is inserted between words.
    /// Note:
    /// A word is defined as a character sequence consisting of non-space 
    /// characters only.
    /// Each word's length is guaranteed to be greater than 0 and not exceed 
    /// maxWidth.
    /// The input array words contains at least one word.
    /// </summary>
    public IList<string> Execute(string[] words, int maxWidth)
    {
        var result = new List<string>();
        int index = 0;

        while(index < words.Length)
        {
            var currentLineWords = 
                GetWordsForLine(words, maxWidth, ref index);

            string line = 
                FormatLine(currentLineWords, maxWidth, index >= words.Length);
            
            result.Add(line);
        }

        return result;
    }

    private IList<string> GetWordsForLine(string[] words, int maxWidth, ref int index)
    {
        var lineWords = new List<string> { words[index] };
        int currentLength = words[index].Length;
        index++;

        while (index < words.Length)
        {
            if (currentLength + 1 + words[index].Length <= maxWidth)
            {
                lineWords.Add(words[index]);
                currentLength += 1 + words[index].Length;
                index++;
            }
            else
            {
                break;
            }
        }

        return lineWords;
    }

    private string FormatLine(IList<string> words, int maxWidth, bool isLastLine)
    {
        int totalWordsLength = words.Sum(w => w.Length);

        if (isLastLine 
            || words.Count == 1)
        {
            string leftPart = string.Join(" ", words);
            string rightPadding = new string(' ', maxWidth - leftPart.Length);
            return leftPart + rightPadding;
        }

        int totalSpaces = maxWidth - totalWordsLength;
        int gaps = words.Count - 1;
        int spacePerGap = totalSpaces / gaps;
        int extraSpaces = totalSpaces % gaps;

        var row = new StringBuilder();
        for (int i = 0; i < words.Count - 1; i++)
        {
            row.Append(words[i]);
            int spacesToAdd = spacePerGap + (i < extraSpaces ? 1 : 0);
            row.Append(new string(' ', spacesToAdd));
        }
        row.Append(words[^1]);

        return row.ToString();
    }
}
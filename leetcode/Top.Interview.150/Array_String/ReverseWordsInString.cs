using System.Text;

namespace Top.Interview._150.Array_String;

public class ReverseWordsInString
{
    /// <summary>
    /// Given an input string s, reverse the order of the words.
    /// A word is defined as a sequence of non-space characters.
    /// The words in s will be separated by at least one space.
    /// Return a string of the words in reverse order concatenated 
    /// by a single space.
    /// Note that s may contain leading or trailing spaces or 
    /// multiple spaces between two words.
    /// The returned string should only have a single space separating the words.
    ///  Do not include any extra spaces.
    /// </summary>
    public string Execute(string s)
    {
        s = s.Trim();
        var result = new StringBuilder();
        var word = new StringBuilder();
        for(int i = s.Length - 1; i >=0; i--)
        {
            if(s[i] == ' ')
            {
                if(word.Length > 0)
                {
                    Reverse(word);
                    result.Append(word.ToString());
                    result.Append(' ');
                    word.Clear();
                }
            }
            else
            {
                word.Append(s[i]);
            }
        }
        if(word.Length > 0)
        {
            Reverse(word);
            result.Append(word.ToString());
            word.Clear();
        }

        return result.ToString();
    }

    private static void Reverse(StringBuilder sb)
    {
        int left = 0;
        int right = sb.Length - 1;
        while(left < right)
        {
            var temp = sb[left];
            sb[left] = sb[right];
            sb[right] = temp;
            left++;
            right--;
        }
    }

}
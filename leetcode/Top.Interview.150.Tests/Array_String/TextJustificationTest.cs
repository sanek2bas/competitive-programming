using Top.Interview._150.Array_String;

namespace Array_String;

public class TextJustificationTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string[] words, int maxWidth, IList<string> answer)
    {
        var solution = new TextJustification();

        var result = solution.Execute(words, maxWidth);

        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(string[] words, int maxWidth, IList<string> answer)> DataSource()
    {
        yield return (
            new string[] 
            { 
                "This", "is", "an", "example", "of", "text", "justification." 
            },
            16,
            new List<string>
            {  
                "This    is    an",
                "example  of text",
                "justification.  " 
            });

        yield return (
            new string[] 
            { 
                "What", "must", "be", "acknowledgment", "shall", "be" 
            },
            16,
            new List<string>
            {
                "What   must   be",
                "acknowledgment  ",
                "shall be        "
            });

        yield return (
            new string[] 
            { 
                "Science", "is", "what", "we", "understand", "well", "enough", 
                "to", "explain", "to", "a", "computer.", "Art", "is", 
                "everything", "else", "we", "do" 
            },
            20,
            new List<string>
            {
                "Science  is  what we",
                "understand      well",
                "enough to explain to",
                "a  computer.  Art is",
                "everything  else  we",
                "do                  "
            });
    }
}
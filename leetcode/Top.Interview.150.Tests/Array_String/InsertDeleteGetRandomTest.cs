using Top.Interview._150.Array_String;
using Top.Interview._150.Common;

namespace Array_String;

public class InsertDeleteGetRandomTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(Func<RandomizedSet, string[]> function, string[] answer)
    {
        var solution = new InsertDeleteGetRandom();

        var result = solution.Execute(function);

        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(Func<RandomizedSet, string[]> function, string[] answer)> DataSource()
    {
         yield return (
            set =>
            {
                var answers = new List<string>
                {
                    set.Insert(1).ToString(),
                    set.Remove(2).ToString(),
                    set.Insert(2).ToString(),
                    set.Remove(1).ToString(),
                    set.Insert(2).ToString(),
                    set.GetRandom().ToString()
                };
                return answers.ToArray();
            },
            new string[] { "True", "False", "True", "True", "False", "2" });
         yield return (
            set =>
            {
                var answers = new List<string>();
                answers.Add(set.Remove(0).ToString());
                answers.Add(set.Remove(0).ToString());
                answers.Add(set.Insert(0).ToString());
                answers.Add(set.GetRandom().ToString());
                answers.Add(set.Remove(0).ToString());
                answers.Add(set.Insert(0).ToString());
                return answers.ToArray();
            },
            new string[] { "False", "False", "True", "0", "True", "True" });
        
        yield return (
            set =>
            {
                var answers = new List<string>();
                answers.Add(set.Insert(3).ToString());
                answers.Add(set.Remove(3).ToString());
                answers.Add(set.Remove(0).ToString());
                answers.Add(set.Insert(3).ToString());
                answers.Add(set.GetRandom().ToString());
                answers.Add(set.Remove(0).ToString());
                return answers.ToArray();
            },
            new string[] { "True", "True", "False", "True", "3", "False" });
    }
}
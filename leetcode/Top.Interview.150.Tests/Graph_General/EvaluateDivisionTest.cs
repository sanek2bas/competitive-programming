using Top.Interview._150.Graph_General;

namespace Graph_General;

public class EvaluateDivisionTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(
        IList<IList<string>> equations, 
        double[] values, 
        IList<IList<string>> queries,
        double[] answer)
    {
        var solution = new EvaluateDivision();

        var result = 
            solution.Execute(equations, values, queries);
        
        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(IList<IList<string>> equations, 
                        double[] values, 
                        IList<IList<string>> queries,
                        double[] answer)> DataSource()
    {
        yield return (
            new List<IList<string>>
            {
                new List<string> {"a", "b"},
                new List<string> {"b","c"}
            },
            new double[] {2.0, 3.0},
            new List<IList<string>>
            {
                new List<string> {"a", "c"},
                new List<string> {"b","a"},
                new List<string> {"a", "e"},
                new List<string> {"a", "a"},
                new List<string> {"x", "x"}
            },
            new double[] {6.00000, 0.50000, -1.00000, 1.00000, -1.00000}
        );

        yield return (
            new List<IList<string>>
            {
                new List<string> {"a", "b"},
                new List<string> {"b","c"},
                new List<string> {"bc","cd"}
            },
            new double[] {1.5, 2.5, 5.0},
            new List<IList<string>>
            {
                new List<string> {"a", "c"},
                new List<string> {"c","b"},
                new List<string> {"bc", "cd"},
                new List<string> {"cd", "bc"}
            },
            new double[] {3.75000, 0.40000, 5.00000, 0.20000}
        );

        yield return (
            new List<IList<string>>
            {
                new List<string> {"a", "b"}
            },
            new double[] {0.5},
            new List<IList<string>>
            {
                new List<string> {"a", "b"},
                new List<string> {"b","a"},
                new List<string> {"a", "c"},
                new List<string> {"x", "y"}
            },
            new double[] {0.50000, 2.00000, -1.00000, -1.00000}
        );
    }
}
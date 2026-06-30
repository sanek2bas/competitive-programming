using Top.Interview._150.Graph_BFS;

namespace Graph_BFS;

public class MinimumGeneticMutationTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(string startGene, string endGene, string[] bank, int answer)
    {
        var solution = new MinimumGeneticMutation();

        var result = solution.Execute(startGene, endGene, bank);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(string startGene, string endGene, string[] bank, int answer)> DataSource()
    {
        yield return (
            "AACCGGTT",
            "AACCGGTA",
            ["AACCGGTA"],
            1
        );

        yield return (
            "AACCGGTT",
            "AAACGGTA",
            ["AACCGGTA", "AACCGCTA", "AAACGGTA"],
            2
        );
    }
}
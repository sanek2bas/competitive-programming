using Top.Interview._150.Backtracking;

namespace Backtracking;

public class CombinationSumTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] candidates, int target, IList<IList<int>> answer)
    {
        var solution = new CombinationSum();

        var result = 
            solution.Execute(candidates, target);
        
        await Assert.That(result)
                    .IsEquivalentTo(answer);
    }

    public IEnumerable<(int[] candidates, int target, IList<IList<int>> answer)> DataSource()
    {
        yield  return (
            [2, 3, 6, 7], 
            7,
            [
                [2, 2, 3],
                [7]
            ]);

            
        yield  return (
            [2, 3, 5], 
            8,
            [
                [2, 2, 2, 2],
                [2, 3, 3],
                [3, 5]
            ]);
        yield  return (
            [2], 
            1,
            []);          
    }
}
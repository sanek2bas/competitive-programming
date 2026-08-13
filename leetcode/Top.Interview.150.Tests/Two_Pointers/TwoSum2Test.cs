using Top.Interview._150.Two_Pointers;

namespace Two_Pointers;

public class TwoSum2Test
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] numbers, int target, int[] answer)
    {
        var solution = new TwoSum2();

        var result = solution.Execute(numbers, target);

        await Assert.That(result).IsEquivalentTo(answer);
    }

    public IEnumerable<(int[] numbers, int target, int[] answer)> DataSource()
    {
        yield return(
            [2, 7, 11, 15], 
            9,
            [1, 2]);
        
        yield return(
            [2, 3, 4], 
            6,
            [1, 3]);
        
        yield return(
            [-1, 0], 
            -1,
            [1, 2]);
    }
}
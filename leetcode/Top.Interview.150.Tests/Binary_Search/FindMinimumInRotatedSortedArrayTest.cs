public class FindMinimumInRotatedSortedArrayTest
{
    [Test]
    [MethodDataSource(nameof(DataSource))]
    public async Task Solution(int[] numbers, int answer)
    {
        var solution = new FindMinimumInRotatedSortedArray();

        var result = solution.Execute(numbers);
        
        await Assert.That(result).IsEqualTo(answer);
    }

    public IEnumerable<(int[] numbers, int answer)> DataSource()
    {
        yield return (
            new int[] { 3, 4, 5, 1, 2 },
            1);
        yield return (
            new int[] { 4, 5, 6, 7, 0, 1, 2 }, 
            0);
        yield return (
            new int[] { 11, 13, 15, 17 }, 
            11);
        yield return (
            new int[] { 2, 1 },
            1);
    }
}
public class HappyNumber_Test
{
    [Test]
    [Arguments(19, true)]
    [Arguments(2, false)]
    public async Task HappyNumber(int n, bool answer)
    {
        var solution = new HappyNumber();
        var result = solution.Execute(n);
        await Assert.That(result).IsEqualTo(answer);
    }
}